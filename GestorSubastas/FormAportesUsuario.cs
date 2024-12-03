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
using iText.Kernel.Font;
using iText.Layout.Properties;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Colors;
using iText.Commons.Actions.Contexts;
using static Core.Entities.Oferta;
using static Core.Entities.Producto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using GestorSubastas.Helper;


namespace GestorSubastas
{
    public partial class FormAportesUsuario : Form
    {
        private readonly IProjectRepository _projectRepository;
        private readonly TPI_DbContext _context;

        public FormAportesUsuario(IProjectRepository projectRepository, TPI_DbContext context)
        {
            _projectRepository = projectRepository;
            _context = context;

            InitializeComponent();

            this.Load += new EventHandler(FormAportesUsuario_Load);
        }

        private async void FormAportesUsuario_Load(object sender, EventArgs e)
        {
            await CargarUsuarios();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async Task CargarUsuarios()
        {
            if (dataGridView2.Columns.Count == 0)
            {
                dataGridView2.Columns.Add("Correo", "Correo");
                dataGridView2.Columns.Add("UsuarioID", "Usuario ID");
            }

            dataGridView2.Columns["Correo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns["UsuarioID"].Visible = false;

            var usuariosConVentas = await _context.Productos
                .Where(p => p.estadoProducto == EstadoProducto.Vendido)
                .GroupBy(p => p.usuarioID)  
                .Select(g => g.Key) 
                .ToListAsync();

            var usuarios = await _projectRepository.GetUsuarios();

            var usuariosConVentasDatos = usuarios
                .Where(u => usuariosConVentas.Contains(u.usuarioID))  
                .ToList();

            if (usuariosConVentasDatos.Any())
            {
                dataGridView2.Rows.Clear();

                foreach (var usuario in usuariosConVentasDatos)
                {
                    dataGridView2.Rows.Add(usuario.email, usuario.usuarioID);
                }
            }
            else
            {
                MessageBox.Show("No se encontraron usuarios con productos vendidos.");
            }
        }

        private async void generarPDF_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un usuario.");
                return;
            }

            var filaSeleccionada = dataGridView2.SelectedRows[0];

            int usuarioID = Convert.ToInt32(filaSeleccionada.Cells["UsuarioID"].Value);
            string nombreUsuario = filaSeleccionada.Cells["Correo"].Value.ToString();

            var productosVendidos = await _context.Productos
                .Where(p => p.usuarioID == usuarioID && p.estadoProducto == EstadoProducto.Vendido)
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

                string rutaPDF = @$"C:\Users\{Environment.UserName}\Downloads\AporteUsuario.pdf";

                try
                {
                    using (PdfWriter writer = new PdfWriter(rutaPDF))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (Document document = new Document(pdf))
                    {
                        PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                        document.Add(new Paragraph("MEW SubastasInforme de Ganancias del Usuario")
                            .SetFont(boldFont)
                            .SetFontSize(18)
                            .SetTextAlignment(TextAlignment.CENTER));

                        document.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}")
                            .SetFontSize(12)
                            .SetTextAlignment(TextAlignment.RIGHT));

                        document.Add(new Paragraph($"Usuario: {nombreUsuario}")
                            .SetFont(boldFont)
                            .SetFontSize(14));

                        document.Add(new Paragraph(" "));

                        Table table = new Table(new float[] { 1, 3, 2, 2 });
                        table.SetWidth(UnitValue.CreatePercentValue(100));

                        table.AddHeaderCell(new Cell().Add(new Paragraph("ID Producto").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Nombre Producto").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Estado").SetFont(boldFont)));
                        table.AddHeaderCell(new Cell().Add(new Paragraph("Ganancia").SetFont(boldFont)));

                        foreach (var producto in productosConOfertas)
                        {
                            table.AddCell(producto.productoID.ToString());
                            table.AddCell(producto.nombreProducto);
                            table.AddCell(producto.estadoProducto.ToString());
                            table.AddCell($"${producto.montoOfertaMultiplicado:F2}");
                        }

                        document.Add(table);

                        document.Add(new Paragraph(" "));
                        document.Add(new Paragraph($"Aporte total del usuario: ${gananciaTotal:F2}")
                            .SetFont(boldFont)
                            .SetFontSize(14)
                            .SetTextAlignment(TextAlignment.RIGHT));

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
                MessageBox.Show("No se encontraron productos vendidos para el usuario seleccionado.");
            }

        }

        private async void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Rows[e.RowIndex].Cells["UsuarioID"].Value != null)
            {
                int usuarioID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["UsuarioID"].Value);

                var productosVendidos = await _context.Productos
                    .Where(p => p.usuarioID == usuarioID && p.estadoProducto == EstadoProducto.Vendido)
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

                    dataGridView1.DataSource = productosConOfertas;

                    decimal gananciaTotal = productosConOfertas.Sum(p => p.montoOfertaMultiplicado);
                    label4.Text = gananciaTotal.ToString("C2");
                }
                else
                {
                    MessageBox.Show("No se encontraron productos vendidos para el usuario seleccionado.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario válido.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}