using Core.Busisness.Interfaces;
using Core.Data.Interface;

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


        public FormInicio(IProjectRepository projectRepository, ISubastaBusiness subastaBusiness, IProductoBusiness productoBusiness, IOfertaBussiness ofertaBussiness, IUsuarioBussiness usuarioBussiness, IDatosUsuarioBusiness datosUsuarioBusiness)
        {
            _projectRepository = projectRepository;
            _usuarioBussiness = usuarioBussiness;
            _datosUsuarioBusiness = datosUsuarioBusiness;
            _productoBusiness = productoBusiness;
            _ofertaBusiness = ofertaBussiness;
            _subastaBusiness = subastaBusiness;
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

        }

        private void BotonEditar_Click(object sender, EventArgs e)
        {
            var formEditarSubasta = new FormEditarSubasta(_subastaBusiness);
            formEditarSubasta.ShowDialog();
        }
    }
}
