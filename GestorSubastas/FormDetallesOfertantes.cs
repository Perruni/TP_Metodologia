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
            await CargarSubastasActivasAsync();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var productoId = (int)dataGridViewProductos.Rows[e.RowIndex].Cells["productoID"].Value;

                // Realiza la consulta filtrando solo por el productoID, sin Enum.IsDefined
                var ofertantes = _context.Ofertas
                    .Where(o => o.productoID == productoId)
                    .Include(o => o.usuario) // Incluye la entidad relacionada usuario
                    .ToList()  // Ejecuta la consulta y trae los datos a memoria
                    .Where(o => Enum.IsDefined(typeof(EstadoOferta), o.estadoOferta))  // Filtra en memoria por el estado de la oferta
                    .Select(o => new
                    {
                        ofertaID = o.ofertaID,
                        montoOferta = o.montoOferta,
                        fechaOferta = o.fechaOferta,
                        usuarioID = o.usuario.usuarioID,
                        usuario = o.usuario
                    })
                    .ToList();  // Convierte el resultado en una lista

                // Marca la fila seleccionada
                dataGridViewProductos.Rows[e.RowIndex].Selected = true;

                // Asigna los resultados al DataGridView de ofertantes
                dataGridViewOfertantes.DataSource = ofertantes;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                var selectedSubasta = (Subasta)comboBox1.SelectedItem;

                var selectedSubastaId = selectedSubasta.subastaID;

                // Filtrar los productos que pertenecen a la subasta seleccionada
                var productos = _context.Productos
                    .Where(p => p.subastaID == selectedSubastaId)
                    .Select(p => new
                    {
                        productoID = p.productoID,
                        nombreProducto = p.nombreProducto,
                        precioBase = p.precioBase,
                        usuarioID = p.usuarioID,
                        Usuario = p.Usuario,
                        subastaID = p.subastaID,
                        Subasta = p.Subasta,
                    })
                    .ToList();

                // Asignar los productos al DataGridView
                dataGridViewProductos.DataSource = productos;
                dataGridViewProductos.Columns["productoID"].Visible = false; // Ocultar la columna de ID
            }
            else
            {
                // Si no hay subasta seleccionada, limpiar el DataGridView
                dataGridViewProductos.DataSource = null;
                dataGridViewOfertantes.DataSource = null;
            }


        }
        private async Task CargarSubastasActivasAsync()
        {
            try
            {
                // Obtener las subastas activas asincrónicamente
                var subastasActivas = await _subastaBusiness.GetSubastasActivas(); // Asegúrate de tener un método asincrónico en tu negocio

                // Asignar al ComboBox de manera sincronizada después de la carga
                comboBox1.DataSource = subastasActivas;
                comboBox1.DisplayMember = "Titulo";  // Cambia por el nombre de la propiedad
                comboBox1.ValueMember = "subastaID"; // Cambia por el ID de la subasta

                comboBox1.SelectedIndex = -1; // Para no seleccionar ningún ítem inicialmente
            }
            catch (Exception ex)
            {
                // Manejar errores (por ejemplo, si la consulta falla)
                MessageBox.Show($"Error al cargar las subastas activas: {ex.Message}");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
