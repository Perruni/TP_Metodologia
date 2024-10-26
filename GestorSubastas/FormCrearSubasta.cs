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
using static Core.Entities.Subasta;

namespace GestorSubastas
{
    public partial class FormCrearSubasta : Form


    {

        private readonly ISubastaBusiness _subastaBusiness;

        public FormCrearSubasta(ISubastaBusiness subastaBusiness)
        {
            _subastaBusiness = subastaBusiness;
            InitializeComponent();
            CargarMetodosPago();

        }

        private void CargarMetodosPago()
        {
            comboBoxMetodosPago.Items.AddRange(Enum.GetNames(typeof(Subasta.MetodosdePago)));
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            var titulo = textBoxTitulo.Text;
            var fechaInicio = dateTimePickerInicio.Value;
            var fechaFin = dateTimePickerFin.Value;

            if (comboBoxMetodosPago.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un método de pago.");
                return;
            }

            if (!Enum.TryParse<Subasta.MetodosdePago>(comboBoxMetodosPago.SelectedItem.ToString(), out var metodopago))
            {
                MessageBox.Show("Método de pago no válido.");
                return;
            }


            var nuevaSubasta = new Subasta
            {
                titulo = titulo,
                fechaInicio = fechaInicio,
                fechaFinalizado = fechaFin,
                metodosdePago = metodopago

            };

            var resultado = await _subastaBusiness.AddSubasta(nuevaSubasta);



        }
    }
}
    
