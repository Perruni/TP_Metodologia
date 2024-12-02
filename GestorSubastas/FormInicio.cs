using Core.Busisness.Interfaces;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorSubastas
{
    public partial class FormInicio : Form
    {
        private readonly IOfertaBussiness _ofertaBusiness;
        private readonly ISubastaBusiness _subastaBusiness;
        private readonly IProductoBusiness _productoBusiness;
        private readonly IUsuarioBussiness _usuarioBussiness;
        private readonly IDatosUsuarioBusiness _datosUsuarioBusiness;
        private readonly IProjectRepository _projectRepository;
        private readonly TPI_DbContext _context;


        public FormInicio(IProjectRepository projectRepository, ISubastaBusiness subastaBusiness, IProductoBusiness productoBusiness, IOfertaBussiness ofertaBussiness, IUsuarioBussiness usuarioBussiness, IDatosUsuarioBusiness datosUsuarioBusiness, TPI_DbContext context)
        {
            _projectRepository = projectRepository;
            _usuarioBussiness = usuarioBussiness;
            _datosUsuarioBusiness = datosUsuarioBusiness;
            _productoBusiness = productoBusiness;
            _ofertaBusiness = ofertaBussiness;
            _subastaBusiness = subastaBusiness;
            _context = context;
            
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var formCrearSubasta = new FormCrearSubasta(_subastaBusiness);
            formCrearSubasta.ShowDialog();
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var seleccion = comboBox1.SelectedIndex;

            if (seleccion == 0)
            {
                var subastas = await _projectRepository.GetSubastasActivas();
                if (subastas != null && subastas.Any())
                {
                    dataGridView1.DataSource = subastas;
                }
                else
                {
                    MessageBox.Show("No se encontraron subastas activas.");
                }

            }
            else if (seleccion == 1)
            {
                var subastas = await _projectRepository.GetSubastasProximas();
                if (subastas != null && subastas.Any())
                {
                    dataGridView1.DataSource = subastas;
                }
                else
                {
                    MessageBox.Show("No se encontraron subastas proximas.");
                }


            }
            else if (seleccion == 2)
            {
                var subastas = await _projectRepository.GetSubastasFinalizadas();
                if (subastas != null && subastas.Any())
                {
                    dataGridView1.DataSource = subastas;
                }
                else
                {
                    MessageBox.Show("No se encontraron subastas finalizadas.");
                }


            }
            else
            {
                MessageBox.Show("No selecciono ningun elemento.");
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var formSolicitudDeProducto = new FormSolicitudDeProductos(_productoBusiness);
            formSolicitudDeProducto.ShowDialog();
        }

        private void BotonEditar_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado alguna fila en el DataGridView
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una subasta para editar.");
                return;
            }

            // Obtener la subasta seleccionada
            var filaSeleccionada = dataGridView1.SelectedRows[0];
            var subastaSeleccionada = (Subasta)filaSeleccionada.DataBoundItem;

            // Verificar si la subasta seleccionada es activa o próxima
            if (subastaSeleccionada != null)
            {
                // Comprobamos el estado de la subasta
                if (subastaSeleccionada.estadoSubasta == Subasta.EstadoSubasta.Activa || subastaSeleccionada.estadoSubasta == Subasta.EstadoSubasta.Proxima)
                {
                    // Si la subasta es activa o próxima, permitimos la edición
                    var formEditarSubasta = new FormEditarSubasta(_subastaBusiness, subastaSeleccionada, _context);
                    formEditarSubasta.ShowDialog();
                }
                else
                {
                    // Si la subasta no está activa ni próxima, mostramos un mensaje
                    MessageBox.Show("Solo puede editar subastas activas o próximas.");
                }
            }
            else
            {
                MessageBox.Show("No se encontró una subasta válida para editar.");
            }
        }

        private void BotonInformes_Click(object sender, EventArgs e)
        {
            var formInformes = new FormInformes(_projectRepository, _context);
            formInformes.ShowDialog();

        }

        private void FormInicio_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una subasta para ver en detalle.");
                return;
            }

            // Obtener la subasta seleccionada
            var filaSeleccionada = dataGridView1.SelectedRows[0];
            var subastaSeleccionada = (Subasta)filaSeleccionada.DataBoundItem;

            // Verificar si la subasta seleccionada es activa o próxima
            if (subastaSeleccionada != null)
            {
                // Comprobamos el estado de la subasta
                
                    // Si la subasta es activa o próxima, permitimos la edición
                    var formDetallesOfertantes = new FormDetallesOfertantes(_context, _subastaBusiness, subastaSeleccionada);
                    formDetallesOfertantes.ShowDialog();

                
            }
            else
            {
                MessageBox.Show("No se encontró una subasta válida para ver.");
            }

        }
    }
}
