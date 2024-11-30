using Core.Data.Interface;
using Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using static Core.Entities.Oferta;
using static Core.Entities.Producto;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Commons.Actions.Contexts;
using iText.Layout;


namespace GestorSubastas
{
    public partial class FormProductosVendidos : Form
    {

        private readonly IProjectRepository _projectRepository;
        private readonly TPI_DbContext _context;

        public FormProductosVendidos(IProjectRepository projectRepository, TPI_DbContext context)
        {
            InitializeComponent();
            _projectRepository = projectRepository;
            _context = context;

        }

        private async void FormProductosVendidos_Load(object sender, EventArgs e)
        {
            await CargarSubastasFinalizadas();
        }


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado una subasta
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona una subasta antes de generar el PDF.");
                return;
            }

            // Obtener el subastaID desde la selección
            var seleccion = comboBox1.SelectedItem as dynamic;
            int subastaID = seleccion.SubastaID;

            // Obtener los productos vendidos con sus ofertas ganadoras
            var productosVendidos = await _context.Productos
                .Where(p => p.subastaID == subastaID && p.estadoProducto == EstadoProducto.Vendido)
                .ToListAsync();

            if (productosVendidos.Any())
            {
                // Crear una lista combinada de productos con las ofertas ganadoras
                var productosConOfertas = productosVendidos
                    .Select(p => new
                    {
                        p.productoID,
                        p.nombreProducto,
                        p.precioBase,
                        p.estadoProducto,
                        // Obtener las ofertas ganadoras para cada producto
                        ofertas = _context.Ofertas
                            .Where(o => o.productoID == p.productoID && o.estadoOferta == EstadoOferta.Ganadora)
                            .ToList()
                    })
                    .Where(p => p.ofertas.Any()) // Filtrar solo aquellos productos que tengan ofertas ganadoras
                    .SelectMany(p => p.ofertas, (p, oferta) => new
                    {
                        p.productoID,
                        p.nombreProducto,
                        p.precioBase,
                        p.estadoProducto,
                        montoOferta = oferta.montoOferta,  // Monto de la oferta
                        montoOfertaMultiplicado = Convert.ToDecimal(oferta.montoOferta) * 0.10m,  // Ganancia para la empresa (10%)
                        montoVendedor = Convert.ToDecimal(oferta.montoOferta) * 0.90m  // Ganancia para el vendedor (90%)
                    })
                    .ToList();

                // Calcular la ganancia total con base en el monto de las ofertas
                decimal gananciaTotal = productosConOfertas.Sum(p => p.montoOfertaMultiplicado);
                decimal gananciaVendedorTotal = productosConOfertas.Sum(p => p.montoVendedor);

                // Ruta del archivo PDF
                string rutaPDF = @$"C:\Users\{Environment.UserName}\Downloads\ReporteProductosVendidos.pdf";

                try
                {
                    // Crear documento PDF
                    using (PdfWriter writer = new PdfWriter(rutaPDF))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (Document document = new Document(pdf))
                    {
                        // Definir una fuente con estilo negrita
                        PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                        // Agregar título
                        document.Add(new Paragraph("MEW Subastas Informe de Ganancias")
                            .SetFont(boldFont) // Aplicar fuente en negrita
                            .SetFontSize(18)
                            .SetTextAlignment(TextAlignment.CENTER));

                        // Agregar la fecha actual
                        document.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}")
                            .SetFontSize(12)
                            .SetTextAlignment(TextAlignment.RIGHT));

                        // Agregar información general de la subasta
                        document.Add(new Paragraph($"Subasta: {seleccion.Titulo}")
                            .SetFont(boldFont) // Aplicar fuente en negrita
                            .SetFontSize(14));

                        // Agregar espacio
                        document.Add(new Paragraph(" "));

                        // Crear tabla para los productos
                        Table table = new Table(new float[] { 1, 3, 2, 2, 2, 2 }); // Columnas: ID, Nombre, Precio Base, Estado, Ganancia Empresa, Ganancia Vendedor
                        table.SetWidth(UnitValue.CreatePercentValue(100));

                        // Encabezados de la tabla
                        table.AddHeaderCell(new Cell().Add(new Paragraph("ID Producto").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Nombre Producto").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Estado").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Ganancia Empresa").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Ganancia Vendedor").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Monto Oferta").SetFont(boldFont)));

                        // Llenar la tabla con los datos de productos y ofertas
                        foreach (var producto in productosConOfertas)
                        {
                            table.AddCell(producto.productoID.ToString());
                            table.AddCell(producto.nombreProducto);
                            table.AddCell(producto.estadoProducto.ToString());
                            table.AddCell($"${producto.montoOfertaMultiplicado:F2}"); // Ganancia para la empresa
                            table.AddCell($"${producto.montoVendedor:F2}"); // Ganancia para el vendedor
                            table.AddCell($"${producto.montoOferta:F2}"); // Monto de la oferta
                        }

                        // Agregar la tabla al documento
                        document.Add(table);

                        // Agregar ganancia total al final del PDF
                        document.Add(new Paragraph(" "));
                        document.Add(new Paragraph($"Ganancia total para la empresa: ${gananciaTotal:F2}")
                            .SetFont(boldFont)
                            .SetFontSize(14)
                            .SetTextAlignment(TextAlignment.RIGHT));

                        document.Add(new Paragraph($"Ganancia total para los vendedores: ${gananciaVendedorTotal:F2}")
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

        private async Task CargarSubastasFinalizadas()
        {
            var subastas = await _projectRepository.GetSubastasFinalizadas();

            if (subastas != null && subastas.Any())
            {
                comboBox1.Items.Clear();

                foreach (var subasta in subastas)
                {
                    comboBox1.Items.Add(new { Titulo = subasta.titulo, SubastaID = subasta.subastaID });
                }

            }
            else
            {
                MessageBox.Show("No se encontraron subastas finalizadas.");
            }
        }

        private void ConfigurarColumnasDataGridView3()
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seleccion = comboBox1.SelectedItem as dynamic;

            if (seleccion != null)
            {
                // Obtenemos el subastaID
                int subastaID = seleccion.SubastaID;

                // Obtener los productos directamente desde la base de datos
                var productosVendidos = await _context.Productos
                    .Where(p => p.subastaID == subastaID && p.estadoProducto == EstadoProducto.Vendido) // Filtrar productos por subastaID y estado "Vendido"
                    .ToListAsync();

                if (productosVendidos.Any())
                {
                    // Crear una lista combinada de productos con las ofertas ganadoras
                    var productosConOfertas = productosVendidos
                        .Select(p => new
                        {
                            p.productoID,
                            p.nombreProducto,
                            p.precioBase,
                            p.estadoProducto,
                            // Obtener las ofertas ganadoras para cada producto
                            ofertas = _context.Ofertas
                                .Where(o => o.productoID == p.productoID && o.estadoOferta == EstadoOferta.Ganadora)
                                .ToList()
                        })
                        .Where(p => p.ofertas.Any()) // Filtrar solo aquellos productos que tengan ofertas ganadoras
                        .SelectMany(p => p.ofertas, (p, oferta) => new
                        {
                            p.productoID,
                            p.nombreProducto,
                            p.precioBase,
                            p.estadoProducto,
                            montoOferta = oferta.montoOferta,  // Monto de la oferta
                            montoOfertaMultiplicado = Convert.ToDecimal(oferta.montoOferta) * 0.10m,  // Ganancia para la empresa (10%)
                            montoVendedor = Convert.ToDecimal(oferta.montoOferta) * 0.90m  // Ganancia para el vendedor (90%)
                        })
                        .ToList();

                    // Asignar la lista combinada al DataGridView
                    dataGridView1.DataSource = productosConOfertas;

                    // Calcular las ganancias con base en el monto de las ofertas
                    decimal gananciaTotal = productosConOfertas.Sum(p => p.montoOfertaMultiplicado);
                    decimal gananciaVendedorTotal = productosConOfertas.Sum(p => p.montoVendedor);
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
    }
}

