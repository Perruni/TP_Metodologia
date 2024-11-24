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

        private void FormProductosVendidos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {

            var productosVendidos = _context.Productos
                .Where(p => p.estadoProducto == Producto.EstadoProducto.Vendido)
                .Select(p => new
                {
                    productoID = p.productoID,
                    nombreProducto = p.nombreProducto,
                    precioBase = p.precioBase,
                    estadoProducto = p.estadoProducto,
                })
                .ToList();

            dataGridView1.DataSource = productosVendidos;


            var ofertasProductosVendidos = _context.Productos
                .Where(p => p.estadoProducto == Producto.EstadoProducto.Vendido && p.listaOfertas != null)
                .Select(p => new
                {
                    productoID = p.productoID,

                    OfertasGanadoras = p.listaOfertas
                        .Where(o => o.estadoOferta == EstadoOferta.Ganadora)
                        .OrderByDescending(o => o.montoOferta)
                        .ToList()
                })
                .ToList();

            dataGridView2.DataSource = ofertasProductosVendidos;
        }



        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void CargarOfertasYGanancias(int productoID)
        {     

           var ganancias = _context.Productos
          .Where(p => p.productoID == productoID && p.estadoProducto == Producto.EstadoProducto.Vendido)
          .Select(p => new
          {
              productoID = p.productoID,
              // Aquí obtenemos la oferta ganadora (si existe)
              ofertaGanadora = p.listaOfertas
                  .Where(o => o.estadoOferta == EstadoOferta.Ganadora)
                  .OrderByDescending(o => o.montoOferta)
                  .FirstOrDefault(),
          })
          .ToList();

            // Calculamos las ganancias fuera de la consulta LINQ (para evitar el uso de `??` dentro del árbol de expresión)
            var gananciasCalculadas = ganancias.Select(g => new
            {
                g.productoID,
                ofertaGanadoraMonto = g.ofertaGanadora?.montoOferta ?? 0, // Si no hay oferta ganadora, se usa 0
                gananciaEmpresa = (g.ofertaGanadora?.montoOferta ?? 0) * 0.1, // 10% para la empresa
                gananciaVendedor = (g.ofertaGanadora?.montoOferta ?? 0) * 0.9 // 90% para el vendedor
            }).ToList();

            ConfigurarColumnasDataGridView3();
            dataGridView3.DataSource = gananciasCalculadas;
        }

        private void ConfigurarColumnasDataGridView3()
        {
           
            dataGridView3.Columns.Clear();

            
            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "productoID",
                HeaderText = "ID Producto",
                ReadOnly = true
            });

            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ofertaGanadoraMonto",
                HeaderText = "Monto Oferta Ganadora",
                DefaultCellStyle = { Format = "C2" } // Formato de moneda
            });

            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "gananciaEmpresa",
                HeaderText = "Ganancia Empresa",
                DefaultCellStyle = { Format = "C2" } // Formato de moneda
            });

            dataGridView3.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "gananciaVendedor",
                HeaderText = "Ganancia Vendedor",
                DefaultCellStyle = { Format = "C2" } // Formato de moneda
            });
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                // Obtiene el ID del producto seleccionado
                int productoID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["productoID"].Value);

               
                CargarOfertasYGanancias(productoID);
            }
        }

    }
}
