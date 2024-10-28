using Core.Busisness.Interfaces;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

            ProductoDescripcion = new TextBox
            {
                Multiline = true,
                Width = 150,  // Ancho del TextBox
                Height = 100, // Alto del TextBox
                Location = new Point(362, 271),
                ScrollBars = ScrollBars.Vertical, // Agregar barra de desplazamiento
                ReadOnly = true // Hacerlo solo de lectura
            };

            this.Controls.Add(ProductoDescripcion); // Agregar el TextBox al formulario
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

        private async void CargarDatosProducto()
        {
            ProductoNombre.Text = _producto.nombreProducto;
            ProductoPrecio.Text = _producto.precioBase.ToString("C", new CultureInfo("es-AR"));
            ProductoEntrega.Text = _producto.metodoEntrega;
            ProductoDescripcion.Text = _producto.descripcion;
            string imageUrl = "https://tpimetodologiaimagenes.blob.core.windows.net/contenedorimagenes/" + _producto.ImagenUrl;

            // Cargar la imagen en el PictureBox de forma asíncrona
            await LoadImageFromUrlAsync(imageUrl);
        }

        private async Task LoadImageFromUrlAsync(string imageUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Descargar los datos de la imagen como un arreglo de bytes
                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);

                    // Convertir los bytes en un objeto Image y asignarlo al PictureBox
                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        using (var originalImage = Image.FromStream(ms))
                        {
                            // Definir el tamaño máximo
                            const int maxWidth = 200;  // Ancho máximo
                            const int maxHeight = 200; // Alto máximo

                            // Calcular la escala
                            double ratioX = (double)maxWidth / originalImage.Width;
                            double ratioY = (double)maxHeight / originalImage.Height;
                            double ratio = Math.Min(ratioX, ratioY);

                            // Calcular las dimensiones escaladas
                            int newWidth = (int)(originalImage.Width * ratio);
                            int newHeight = (int)(originalImage.Height * ratio);

                            // Crear la imagen escalada
                            using (var newImage = new Bitmap(originalImage, newWidth, newHeight))
                            {
                                ImagenProducto.Image = new Bitmap(newImage); // Asignar la imagen escalada al PictureBox
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
            }
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
            _producto.estadoSolicitud = Producto.EstadoSolicitud.Rechazado;
            


            var resultado = _productoBusiness.UpdateProducto(_producto);

            MessageBox.Show("Producto rechazado.");
            this.Close();
        }

        private void FormSolicitudDeProductos_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Comprobar que se hace clic en una fila válida
            {
                _producto = (Producto)dataGridViewSubastas.Rows[e.RowIndex].DataBoundItem;
                CargarDatosProducto();
            }
            
        }
    }
}