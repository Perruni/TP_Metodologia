using Core.Busisness.Interfaces;
using Core.Data;
using Core.Data.Interface;
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


namespace GestorSubastas
{
    public partial class FormInformes : Form
    {

        private readonly ISubastaBusiness _subastaBusiness;
        private readonly TPI_DbContext _context;
        private readonly IProjectRepository _projectRepository;
        public FormInformes(ISubastaBusiness subastaBusiness, TPI_DbContext context)
        {
            InitializeComponent();
            _subastaBusiness = subastaBusiness;
            _context = context;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formDetallesOfertantes = new FormDetallesOfertantes(_context, _subastaBusiness);
            formDetallesOfertantes.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormInformes_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxInformes(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var formGestionGanancias = new FormGestionGanancias(_projectRepository, _context);
            formGestionGanancias.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var formProductosVendidos = new FormProductosVendidos(_projectRepository, _context);
            formProductosVendidos.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var formProductosNOOfertados = new FormProductosNOOfertados(_projectRepository, _context);
            formProductosNOOfertados.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
