using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Core.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Data.Interface;
using iText.Layout.Properties;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Colors;
using Core.Entities;

namespace GestorSubastas
{
    public partial class FormProductosNOOfertados : Form
    {

        private readonly List<Producto> _productosSinOfertas;
        private readonly TPI_DbContext _context;

        public FormProductosNOOfertados(List<Producto> productosSinOfertas, TPI_DbContext context)
        {
            _productosSinOfertas = productosSinOfertas;
            _context = context;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async Task CargarProductosSinOfertas()
        {
            try
            {



                dataGridView1.DataSource = _productosSinOfertas.Select(p => new
                {
                    p.productoID,
                    p.nombreProducto,
                    p.precioBase,
                    p.estadoProducto


                }).ToList();


                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos sin ofertas: " + ex.Message);
            }
        }

        private async void FormProductosNOOfertados_Load(object sender, EventArgs e)
        {
            await CargarProductosSinOfertas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Cambia la ruta al directorio de Downloads o especifica otra ruta
                string filePath = @$"C:\Users\{Environment.UserName}\Downloads\productos_sin_ofertas.pdf";

                // Verifica si el archivo ya existe
                if (File.Exists(filePath))
                {
                    // Si el archivo existe, pregunta si se debe sobrescribir
                    var result = MessageBox.Show("El archivo ya existe. ¿Quieres sobrescribirlo?", "Confirmar sobrescritura", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                        return;  // Si no, cancela la operación
                    File.Delete(filePath);  // Elimina el archivo existente
                }

                // Crea el documento PDF
                using (var writer = new PdfWriter(filePath))
                {
                    using (var pdf = new PdfDocument(writer))
                    {
                        var document = new Document(pdf);

                        // Título
                        document.Add(new Paragraph("MEW Subastas Productos sin Ofertas")
                            .SetFontSize(18)
                            .SetTextAlignment(TextAlignment.CENTER));

                        // Separación
                        document.Add(new Paragraph("\n"));

                        // Crear tabla con el número de columnas de tu DataGridView
                        var table = new Table(dataGridView1.ColumnCount)
                            .UseAllAvailableWidth()
                            .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);

                        // Agregar los encabezados de las columnas
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            table.AddHeaderCell(new Cell().Add(new Paragraph(column.HeaderText)));
                        }

                        // Agregar las filas de datos
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue; // Ignorar la fila nueva
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                table.AddCell(new Paragraph(cell.Value?.ToString() ?? string.Empty));
                            }
                        }

                        // Agregar la tabla al documento
                        document.Add(table);
                    }
                }

                MessageBox.Show("El archivo PDF fue generado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
        }
    }
}
