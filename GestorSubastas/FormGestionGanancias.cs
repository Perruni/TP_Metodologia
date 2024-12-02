using Core.Busisness;
using Core.Busisness.Interfaces;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
using iText.Commons.Actions.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Layout.Properties;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Colors;
using static Core.Entities.Oferta;
using static Core.Entities.Producto;
using iText.Kernel.Font;

namespace GestorSubastas
{
    public partial class FormGestionGanancias : Form
    {

        private readonly IProjectRepository _projectRepository;
        private readonly TPI_DbContext _context;




        public FormGestionGanancias(IProjectRepository projectRepository, TPI_DbContext context)
        {

            _projectRepository = projectRepository;
            _context = context;

            InitializeComponent();
        }

        private void productoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private async void FormGestionGanancias_Load(object sender, EventArgs e)
        {

            await CargarSubastasFinalizadas();
        }

        private async Task CargarSubastasFinalizadas()
        {
            var subastas = await _projectRepository.GetSubastasFinalizadas();

            if (subastas != null && subastas.Any())
            {
                ComboFinalizadas.Items.Clear();

                foreach (var subasta in subastas)
                {
                    ComboFinalizadas.Items.Add(new { Titulo = subasta.titulo, SubastaID = subasta.subastaID });
                }

            }
            else
            {
                MessageBox.Show("No se encontraron subastas finalizadas.");
            }
        }

        private async void ComboFinalizadas_SelectedIndexChanged(object sender, EventArgs e)
        {

            var seleccion = ComboFinalizadas.SelectedItem as dynamic;

            if (seleccion != null)
            {
                int subastaID = seleccion.SubastaID;

                var productosVendidos = await _context.Productos
                    .Where(p => p.subastaID == subastaID && p.estadoProducto == EstadoProducto.Vendido)
                    .ToListAsync();

                if (productosVendidos.Any())
                {
                    var productosConOfertas = productosVendidos
                        .Select(p => new
                        {
                            p.productoID,
                            p.nombreProducto,
                            p.precioBase,
                            p.estadoProducto,
                            ofertas = _context.Ofertas
                                .Where(o => o.productoID == p.productoID && o.estadoOferta == EstadoOferta.Ganadora)
                                .ToList()
                        })
                        .Where(p => p.ofertas.Any())
                        .SelectMany(p => p.ofertas, (p, oferta) => new
                        {
                            p.productoID,
                            p.nombreProducto,
                            p.precioBase,
                            p.estadoProducto,
                            montoOferta = oferta.montoOferta,
                            montoOfertaMultiplicado = Convert.ToDecimal(oferta.montoOferta) * 0.10m
                        })
                        .ToList();

                    GridProductosG.DataSource = productosConOfertas;

                    decimal gananciaTotal = productosConOfertas.Sum(p => p.montoOfertaMultiplicado);
                    label3.Text = $"Ganancia total para la empresa: ${gananciaTotal:F2}";
                }
                else
                {
                    MessageBox.Show("No se encontraron productos vendidos para la subasta seleccionada.");
                }

            }
            else
            {
                MessageBox.Show("No se seleccionó una subasta válida.");
            }
        }
        private void GridProductosG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void generarpdf_Click(object sender, EventArgs e)
        {
            if (ComboFinalizadas.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una subasta antes de generar el PDF.");
                return;
            }

            var seleccion = ComboFinalizadas.SelectedItem as dynamic;
            int subastaID = seleccion.SubastaID;

            var productosVendidos = await _context.Productos
                .Where(p => p.subastaID == subastaID && p.estadoProducto == EstadoProducto.Vendido)
                .ToListAsync();

            if (productosVendidos.Any())
            {
                var productosConOfertas = productosVendidos
                    .Select(p => new
                    {
                        p.productoID,
                        p.nombreProducto,
                        p.precioBase,
                        p.estadoProducto,
                        ofertas = _context.Ofertas
                            .Where(o => o.productoID == p.productoID && o.estadoOferta == EstadoOferta.Ganadora)
                            .ToList()
                    })
                    .Where(p => p.ofertas.Any())
                    .SelectMany(p => p.ofertas, (p, oferta) => new
                    {
                        p.productoID,
                        p.nombreProducto,
                        p.precioBase,
                        p.estadoProducto,
                        montoOferta = oferta.montoOferta,
                        montoOfertaMultiplicado = Convert.ToDecimal(oferta.montoOferta) * 0.10m
                    })
                    .ToList();

                decimal gananciaTotal = productosConOfertas.Sum(p => p.montoOfertaMultiplicado);
                label3.Text = $"Ganancia total para la empresa: ${gananciaTotal:F2}";
                string rutaPDF = @$"C:\Users\{Environment.UserName}\Downloads\ReporteSubastaganancias.pdf";

                try
                {
                    using (PdfWriter writer = new PdfWriter(rutaPDF))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (Document document = new Document(pdf))
                    {
                        PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                        document.Add(new Paragraph("MEW Subastas Informe de Ganancias")
                            .SetFont(boldFont)
                            .SetFontSize(18)
                            .SetTextAlignment(TextAlignment.CENTER));

                        // Agregar la fecha actual
                        document.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}")
                            .SetFontSize(12)
                            .SetTextAlignment(TextAlignment.RIGHT));

                        // Agregar información general de la subasta
                        document.Add(new Paragraph($"Subasta: {seleccion.Titulo}")
                            .SetFont(boldFont)
                            .SetFontSize(14));

                        // Agregar espacio
                        document.Add(new Paragraph(" "));

                        // Crear tabla para los productos
                        Table table = new Table(new float[] { 1, 3, 2, 2 });
                        table.SetWidth(UnitValue.CreatePercentValue(100));

                        // Encabezados de la tabla
                        table.AddHeaderCell(new Cell().Add(new Paragraph("ID Producto").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Nombre Producto").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Estado").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Ganancia").SetFont(boldFont)));

                        // Llenar la tabla con los datos de productos y ofertas
                        foreach (var producto in productosConOfertas)
                        {
                            table.AddCell(producto.productoID.ToString());
                            table.AddCell(producto.nombreProducto);
                            table.AddCell(producto.estadoProducto.ToString());
                            table.AddCell($"${producto.montoOfertaMultiplicado:F2}");
                        }

                        // Agregar la tabla al documento
                        document.Add(table);

                        // Agregar ganancia total al final del PDF
                        document.Add(new Paragraph(" "));
                        document.Add(new Paragraph($"Ganancia total para la empresa: ${gananciaTotal:F2}")
                            .SetFont(boldFont)
                            .SetFontSize(14)
                            .SetTextAlignment(TextAlignment.RIGHT));

                        // Mensaje de confirmación
                        MessageBox.Show($"PDF generado correctamente en {rutaPDF}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar el PDF: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No se encontraron productos vendidos para la subasta seleccionada.");
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
