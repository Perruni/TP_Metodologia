using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Core.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Data.Interface;

namespace GestorSubastas
{
    public partial class FormProductosNOOfertados : Form
    {

        private readonly IProjectRepository _projectRepository;
        private readonly TPI_DbContext _context;

        public FormProductosNOOfertados(IProjectRepository projectRepository, TPI_DbContext context)
        {
            _projectRepository = projectRepository;
            _context = context;
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async Task CargarProductosSinOfertas()
        {
            try
            {
               
                var productosSinOfertas = await _projectRepository.GetProductosSinOfertas();

                
                dataGridView1.DataSource = productosSinOfertas.Select(p => new
                {
                    p.productoID,
                    p.nombreProducto,
                    p.precioBase,   
                    
                }).ToList();

                
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los productos sin ofertas: " + ex.Message);
            }
        }

        private async void FormProductosNOOfertados_Load(object sender, EventArgs e)
        {
            await CargarProductosSinOfertas();
        }
    }
}
