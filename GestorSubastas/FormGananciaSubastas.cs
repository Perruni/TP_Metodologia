using Core.Data;
using Microsoft.EntityFrameworkCore;
using Core.Data.Interface;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Core.Entities.Oferta;
using static Core.Entities.Producto;
using iText.Kernel.Font;
using iText.Layout.Properties;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Colors;
using iText.Commons.Actions.Contexts;


namespace GestorSubastas
{
    public partial class FormGananciaSubastas : Form
    {
        private readonly IProjectRepository _projectRepository;
        private readonly TPI_DbContext _context;

        public FormGananciaSubastas(IProjectRepository projectRepository, TPI_DbContext context)
        {

            _projectRepository = projectRepository;
            _context = context;

            InitializeComponent();
        }

        private async void Buscar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePickerInicio.Value.Date;
            DateTime fechaFin = dateTimePickerFin.Value.Date;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de finalización.");
                return;
            }

            var subastasFiltradas = await _context.Subastas
                .Where(s => s.fechaFinalizado >= fechaInicio
                            && s.fechaFinalizado <= fechaFin
                            && s.estadoSubasta == Subasta.EstadoSubasta.Finalizadas)
                .ToListAsync();

            if (subastasFiltradas.Any())
            {
                var resultados = new List<object>();

                foreach (var subasta in subastasFiltradas)
                {
                    var productosVendidos = await _context.Productos
                        .Where(p => p.subastaID == subasta.subastaID && p.estadoProducto == EstadoProducto.Vendido)
                        .ToListAsync();

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
                            p.estadoProducto,
                            montoOferta = oferta.montoOferta,
                            montoOfertaMultiplicado = Convert.ToDecimal(oferta.montoOferta) * 0.10m
                        })
                        .ToList();

                    decimal gananciaSubasta = productosConOfertas.Sum(p => p.montoOfertaMultiplicado);

                    resultados.Add(new
                    {
                        subasta.titulo,
                        subasta.fechaInicio,
                        subasta.fechaFinalizado,
                        Ganancia = gananciaSubasta
                    });
                }

                dataGridView1.DataSource = resultados;

                if (!resultados.Any())
                {
                    MessageBox.Show("No se encontraron subastas dentro del rango de fechas especificado.");
                }
            }
            else
            {
                MessageBox.Show("No se encontraron subastas dentro del rango de fechas.");
            }
        }

        private async void generarpdf_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePickerInicio.Value.Date;
            DateTime fechaFin = dateTimePickerFin.Value.Date;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de finalización.");
                return;
            }

            var subastasFiltradas = await _context.Subastas
                .Where(s => s.fechaFinalizado >= fechaInicio
                            && s.fechaFinalizado <= fechaFin
                            && s.estadoSubasta == Subasta.EstadoSubasta.Finalizadas)
                .ToListAsync();

            string rutaPDF = @$"C:\Users\{Environment.UserName}\Downloads\RangoGanancias.pdf";

            try
            {
                using (PdfWriter writer = new PdfWriter(rutaPDF))
                using (PdfDocument pdf = new PdfDocument(writer))
                using (Document document = new Document(pdf))
                {
                    PdfFont boldFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);

                    document.Add(new Paragraph("MEW Subastas Informe de Ganancias de Subastas")
                        .SetFont(boldFont)
                        .SetFontSize(18)
                        .SetTextAlignment(TextAlignment.CENTER));

                    document.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy}")
                        .SetFontSize(12)
                        .SetTextAlignment(TextAlignment.RIGHT));

                    document.Add(new Paragraph($"Rango de fechas: {fechaInicio:dd/MM/yyyy} - {fechaFin:dd/MM/yyyy}")
                        .SetFontSize(12)
                        .SetTextAlignment(TextAlignment.RIGHT));

                    document.Add(new Paragraph(" "));

                    Table table = new Table(new float[] { 1, 3, 2, 2 });
                    table.SetWidth(UnitValue.CreatePercentValue(100));

                    table.AddHeaderCell(new Cell().Add(new Paragraph("Subasta").SetFont(boldFont)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Fecha Inicio").SetFont(boldFont)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Fecha Finalizado").SetFont(boldFont)));
                    table.AddHeaderCell(new Cell().Add(new Paragraph("Ganancia").SetFont(boldFont)));

                    decimal gananciaTotal = 0;

                    foreach (var subasta in subastasFiltradas)
                    {
                        var productosVendidos = await _context.Productos
                            .Where(p => p.subastaID == subasta.subastaID && p.estadoProducto == EstadoProducto.Vendido)
                            .ToListAsync();

                        var productosConOfertas = productosVendidos
                            .Select(p => new
                            {
                                p.productoID,
                                p.nombreProducto,
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
                                p.estadoProducto,
                                montoOferta = oferta.montoOferta,
                                montoOfertaMultiplicado = Convert.ToDecimal(oferta.montoOferta) * 0.10m
                            })
                            .ToList();

                        decimal gananciaSubasta = productosConOfertas.Sum(p => p.montoOfertaMultiplicado);

                        gananciaTotal += gananciaSubasta;

                        table.AddCell(subasta.titulo);
                        table.AddCell(subasta.fechaInicio.ToString("dd/MM/yyyy"));
                        table.AddCell(subasta.fechaFinalizado.ToString("dd/MM/yyyy"));
                        table.AddCell($"${gananciaSubasta:F2}");
                    }

                    document.Add(table);

                    document.Add(new Paragraph(" "));

                    document.Add(new Paragraph($"Ganancia total para el rango de fechas: ${gananciaTotal:F2}")
                        .SetFont(boldFont)
                        .SetFontSize(14)
                        .SetTextAlignment(TextAlignment.RIGHT));

                    MessageBox.Show($"PDF generado correctamente en: {rutaPDF}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}");
            }
        }

    }
}
