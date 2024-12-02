using Core.Busisness;
using Core.Busisness.Interfaces;
using Core.Data;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GestorSubastas
{
    public partial class FormEditarSubasta : Form
    {
        private readonly ISubastaBusiness _subastaBusiness;
        private Subasta _subastaSeleccionada;
        private TPI_DbContext _context;

        public FormEditarSubasta(ISubastaBusiness subastaBusiness, Subasta subastaSeleccionada, TPI_DbContext context)
        {
            _subastaBusiness = subastaBusiness;
            _subastaSeleccionada = subastaSeleccionada;
            _context = context;
            InitializeComponent();
            CargarMetodosPago1();
            CargarEstadosSubasta();
            CargarDatosSubasta();
        }

        private void CargarMetodosPago1()
        {
            comboBoxMetodosPago.Items.AddRange(Enum.GetNames(typeof(Subasta.MetodosdePago)));
        }

        private void CargarEstadosSubasta()
        {
            comboBoxEstadodeSubasta.Items.AddRange(Enum.GetNames(typeof(Subasta.EstadoSubasta)));
        }

        private void CargarDatosSubasta()
        {
            if (_subastaSeleccionada != null)
            {
                textBox1.Text = _subastaSeleccionada.titulo; // Mostrar el título en el TextBox
                dateTimePickerInicio.Value = _subastaSeleccionada.fechaInicio;
                dateTimePickerFin.Value = _subastaSeleccionada.fechaFinalizado;
                comboBoxMetodosPago.SelectedItem = _subastaSeleccionada.metodosdePago.ToString();
                comboBoxEstadodeSubasta.SelectedItem = _subastaSeleccionada.estadoSubasta.ToString();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Por favor, ingrese un título para la subasta.");
                return;
            }

            var subastaSeleccionada = _subastaSeleccionada; // Usar la subasta seleccionada previamente

            var fechaInicio = dateTimePickerInicio.Value;
            var fechaFin = dateTimePickerFin.Value;

            if (comboBoxMetodosPago.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un método de pago.");
                return;
            }

            if (comboBoxEstadodeSubasta.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un estado de subasta.");
                return;
            }

            if (!Enum.TryParse<Subasta.MetodosdePago>(comboBoxMetodosPago.SelectedItem.ToString(), out var metodopago))
            {
                MessageBox.Show("Método de pago no válido.");
                return;
            }
            if (!Enum.TryParse<Subasta.EstadoSubasta>(comboBoxEstadodeSubasta.SelectedItem.ToString(), out var estadoSubasta))
            {
                MessageBox.Show("Estado de subasta no válido.");
                return;
            }

            var subastaActualizada = new Subasta
            {
                subastaID = subastaSeleccionada.subastaID,  // Mantener el mismo ID de la subasta
                titulo = textBox1.Text,  // Obtener el título desde el TextBox
                fechaInicio = fechaInicio,
                fechaFinalizado = fechaFin,
                metodosdePago = metodopago,
                estadoSubasta = estadoSubasta
            };

            // Desvincula la entidad antes de actualizarla
            _context.Entry(subastaSeleccionada).State = EntityState.Detached;

            // Ahora intenta actualizarla
            var resultado = await _subastaBusiness.UpdateSubasta(subastaActualizada);

            if (subastaActualizada.estadoSubasta == Subasta.EstadoSubasta.Activa)
            {
                var productosAsociados = await _context.Productos
                    .Where(p => p.subastaID == subastaActualizada.subastaID && p.estadoSolicitud == Producto.EstadoSolicitud.Aprobado)
                    .ToListAsync();

                foreach (var producto in productosAsociados)
                {
                    producto.estadoProducto = Producto.EstadoProducto.EnSubasta;
                    _context.Productos.Update(producto);
                }

                await _context.SaveChangesAsync();
            }

            if (resultado != null)
            {
                MessageBox.Show("Subasta actualizada exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al actualizar la subasta.");
            }
        }

        private void FormEditarSubasta_Load(object sender, EventArgs e)
        {
            // Cualquier inicialización adicional que se necesite
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Si necesitas manejar el evento de cambio de texto
        }
    }
}
