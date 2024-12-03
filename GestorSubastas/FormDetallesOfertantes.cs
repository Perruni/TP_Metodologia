using Core.Busisness.Interfaces;
using Core.Data;
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


namespace GestorSubastas
{
    public partial class FormDetallesOfertantes : Form
    {

        private readonly TPI_DbContext _context;
        private readonly ISubastaBusiness _subastaBusiness;
        private readonly Subasta _subasta;
        public FormDetallesOfertantes(TPI_DbContext context, ISubastaBusiness subastaBusiness, Subasta subasta)
        {

            _context = context;
            _subastaBusiness = subastaBusiness;
            _subasta = subasta;
            InitializeComponent();

            this.Load += new EventHandler(FormDetallesOfertantes_Load);

        }


        private async void FormDetallesOfertantes_Load(object sender, EventArgs e)
        {

            label9.Text = _subasta.titulo;

            await CargarSubastasActivasAsync();

        }

        private async void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var productoId = (int)dataGridViewProductos.Rows[e.RowIndex].Cells["productoID"].Value;

                var producto = await _context.Productos
                    .Where(p => p.productoID == productoId)
                    .FirstOrDefaultAsync();

                if (producto != null)
                {
                    var cantidadOfertas = await _context.Ofertas
                        .Where(o => o.productoID == productoId)
                        .CountAsync();

                    label6.Text = $"Cantidad de ofertas: {cantidadOfertas}";
                    label8.Text = producto.descripcion;
                    label8.Width = 50; 
                    label8.Height = 200;  

                    label8.BorderStyle = BorderStyle.FixedSingle;

                    label8.TextAlign = ContentAlignment.MiddleCenter;

                    if (!string.IsNullOrEmpty(producto.ImagenUrl))
                    {
                        try
                        {
                            string baseUri = "https://tpimetodologiaimagenes.blob.core.windows.net/contenedorimagenes/";
                            Uri imageUri = new Uri(baseUri + producto.ImagenUrl);

                            using (var webClient = new System.Net.WebClient())
                            {
                                byte[] imageBytes = await webClient.DownloadDataTaskAsync(imageUri);
                                using (var ms = new System.IO.MemoryStream(imageBytes))
                                {
                                    var imagen = Image.FromStream(ms);
                                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox1.Image = imagen;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al cargar la imagen: {ex.Message}");
                            pictureBox1.Image = null;
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null;
                    }

                    var ofertantes = await _context.Ofertas
                        .Where(o => o.productoID == productoId)
                        .Include(o => o.usuario)
                        .ToListAsync();

                    dataGridViewOfertantes.Columns.Clear(); // Limpiar las columnas anteriores

                    dataGridViewOfertantes.Columns.Add("ofertaID", "ID de la Oferta");
                    dataGridViewOfertantes.Columns.Add("montoOferta", "Monto de la Oferta");
                    dataGridViewOfertantes.Columns.Add("fechaOferta", "Fecha de la Oferta");
                    dataGridViewOfertantes.Columns.Add("usuario", "Correo");

                    foreach (var ofertante in ofertantes)
                    {
                        dataGridViewOfertantes.Rows.Add(ofertante.ofertaID, ofertante.montoOferta, ofertante.fechaOferta, ofertante.usuario.email);
                    }
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }
        private async Task CargarSubastasActivasAsync()
        {
            var selectedSubasta = _subasta;

            var selectedSubastaId = selectedSubasta.subastaID;

            // Filtrar los productos que pertenecen a la subasta seleccionada
            var productos = _context.Productos
                .Where(p => p.subastaID == selectedSubastaId)
                .Select(p => new
                {
                    productoID = p.productoID,
                    nombreProducto = p.nombreProducto,
                    precioBase = p.precioBase,
                    Usuario = p.Usuario.email,
                })
                .ToList();


            dataGridViewProductos.DataSource = productos;

            if (dataGridViewProductos.Columns["productoID"] != null)
                dataGridViewProductos.Columns["productoID"].HeaderText = "ID";

            if (dataGridViewProductos.Columns["nombreProducto"] != null)
                dataGridViewProductos.Columns["nombreProducto"].HeaderText = "Producto";

            if (dataGridViewProductos.Columns["precioBase"] != null)
                dataGridViewProductos.Columns["precioBase"].HeaderText = "Precio Base";

            if (dataGridViewProductos.Columns["usuario"] != null)
                dataGridViewProductos.Columns["usuario"].HeaderText = "Correo del Dueño";

            dataGridViewProductos.Columns["productoID"].Visible = false; // Ocultar la columna de ID
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
