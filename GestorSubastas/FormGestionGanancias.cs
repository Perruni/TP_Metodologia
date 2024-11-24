using Core.Busisness;
using Core.Busisness.Interfaces;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
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
using static Core.Entities.Oferta;
using static Core.Entities.Producto;

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

        private void label2_Click(object sender, EventArgs e)
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

                // Establecer el primer item como seleccionado
                ComboFinalizadas.SelectedIndex = 0;
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
                // Obtenemos el subastaID
                int subastaID = seleccion.SubastaID;

                MessageBox.Show($"Seleccionaste la subasta con ID: {subastaID}");

                
                var subasta = await _projectRepository.GetSubastaProductos(subastaID);

                if (subasta != null)
                {
                    // Filtramos los productos con estadoProducto = 2 (Vendido)
                    var productosVendidos = subasta.listaProductos
                        .Where(p => p.estadoProducto == EstadoProducto.Vendido)
                        .ToList();

                    // Mostrar los productos vendidos en el grid de productos
                    var productos = productosVendidos
                        .Select(p => new
                        {
                            p.productoID,
                            p.nombreProducto,
                            p.precioBase,
                            p.estadoProducto
                        })
                        .ToList();

                    GridProductosG.DataSource = productos;

                    // Calcular las ganancias con base en el monto de las ofertas
                    decimal gananciaTotal = 0;
                    foreach (var producto in productosVendidos)
                    {
                        // Filtrar las ofertas de estadoOferta = 2 (ganadora) para este producto
                        var ofertasFinalizadas = producto.listaOfertas
                            .Where(o => o.estadoOferta == EstadoOferta.Ganadora)
                            .ToList();

                        // Sumar el 10% de cada oferta
                        foreach (var oferta in ofertasFinalizadas)
                        {
                            gananciaTotal += Convert.ToDecimal(oferta.montoOferta) * 0.10m;
                        }
                    }

                    // Mostrar la ganancia total en el label3
                    label3.Text = $"Ganancia total para la empresa: ${gananciaTotal:F2}";


                 var ofertas = productosVendidos
                   .SelectMany(p => p.listaOfertas
                     .Where(o => o.estadoOferta == EstadoOferta.Ganadora))
                     .Select(o => new
                     {
                       o.productoID,
                       o.montoOferta,
                     })
                    .ToList();

                    dataGridView1.DataSource = ofertas;
                }
                else
                {
                    MessageBox.Show("No se encontraron productos para la subasta seleccionada.");
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
    }
}
