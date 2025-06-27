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
        private readonly ISubastaBusiness _subastaBusiness;

        public FormSolicitudDeProductos(IProductoBusiness productoBusiness, ISubastaBusiness subastaBusiness)
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
            _subastaBusiness = subastaBusiness;
            CargarSubastas();


        }

        private void MostrarImagenDesdeRutaLocal(string rutaRelativaWeb)
        {
            // Ruta absoluta de la carpeta donde están las imágenes
            string carpetaUploads = @"C:\Users\Facundo Lesteyme\Documents\Repositorios\2025\Web_Subasta\wwwroot\uploads";

            // Obtener el nombre del archivo desde la ruta relativa web
            string nombreArchivo = Path.GetFileName(rutaRelativaWeb);

            // Combinar con la ruta absoluta
            string rutaAbsoluta = Path.Combine(carpetaUploads, nombreArchivo);

            // Verificar si la imagen existe y cargarla
            if (File.Exists(rutaAbsoluta))
            {
                ImagenProducto.Image = Image.FromFile(rutaAbsoluta);
            }
            else
            {
                MessageBox.Show("La imagen no fue encontrada.\nRuta esperada:\n" + rutaAbsoluta);
            }
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
            MostrarImagenDesdeRutaLocal(_producto.ImagenUrl);

            if (_producto.subastaID.HasValue)
            {
                var subasta = await _subastaBusiness.GetSubasta(_producto.subastaID.Value);

                if (subasta != null)
                {
                    label7.Text = subasta.titulo; // Asumimos que Subasta tiene una propiedad Titulo
                }
                else
                {
                    label7.Text = "Subasta no disponible";
                }
            }
            else
            {
                label7.Text = "Subasta no disponible";
            }

            // Cargar la imagen en el PictureBox de forma asíncrona
            //await LoadImageFromUrlAsync(imageUrl);
        }

        //private async Task LoadImageFromUrlAsync(string imageUrl)
        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);
        //            using (var ms = new System.IO.MemoryStream(imageBytes))
        //            {
        //                using (var originalImage = Image.FromStream(ms))
        //                {
        //                    const int maxWidth = 200;
        //                    const int maxHeight = 200;
        //                    double ratioX = (double)maxWidth / originalImage.Width;
        //                    double ratioY = (double)maxHeight / originalImage.Height;
        //                    double ratio = Math.Min(ratioX, ratioY);
        //                    int newWidth = (int)(originalImage.Width * ratio);
        //                    int newHeight = (int)(originalImage.Height * ratio);
        //                    using (var newImage = new Bitmap(originalImage, newWidth, newHeight))
        //                    {
        //                        ImagenProducto.Image = new Bitmap(newImage);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar errores al cargar la imagen
        //        MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
        //    }
        //}

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
            if (e.RowIndex >= 0)
            {
                dataGridViewSubastas.Rows[e.RowIndex].Selected = true;

                _producto = (Producto)dataGridViewSubastas.Rows[e.RowIndex].DataBoundItem;

                CargarDatosProducto();
            }

        }

        private void ImagenProducto_Click(object sender, EventArgs e)
        {

        }
    }
}