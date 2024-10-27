using Core.Busisness.Interfaces;
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

namespace GestorSubastas
{
    public partial class FormSolicitudDeProductos : Form
    {
        private Producto _producto;
        private readonly IProductoBusiness _productoBusiness;

        public FormSolicitudDeProductos( IProductoBusiness productoBusiness)
        {
            InitializeComponent();

            _productoBusiness = productoBusiness;
            CargarSubastas();
        }

        private async Task CargarSubastas()
        {
  
            List<Producto> todosLosProductos = await _productoBusiness.GetProductos();


            var productosPendientes = todosLosProductos
        .Where(p => p.estadoSolicitud == Producto.EstadoSolicitud.Pendiente)
        .ToList();

            dataGridViewSubastas.DataSource = productosPendientes;
        }

        private void CargarDatosProducto()
        {
            txtNombre.Text = _producto.nombreProducto;
            txtMontoBase.Text = _producto.precioBase.ToString("C");
            txtMetodoEntrega.Text = _producto.metodoEntrega;
            rtxtDescripcion.Text = _producto.descripcion;


        }

        private void button1_ClickAsync(object sender, EventArgs e)
        {

            _producto.estadoSolicitud = Producto.EstadoSolicitud.Aprobado;

            var resultado = _productoBusiness.UpdateProducto(_producto);
            MessageBox.Show("Producto aprobado.");

            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Producto rechazado.");
            this.Close();
        }

        private void FormSolicitudDeProductos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _producto = (Producto)dataGridViewSubastas.Rows[e.RowIndex].DataBoundItem;

            CargarDatosProducto();
        }
    }
}