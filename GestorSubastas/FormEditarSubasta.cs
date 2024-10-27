using Core.Busisness;
using Core.Busisness.Interfaces;
using Core.Entities;
using Org.BouncyCastle.Asn1.Crmf;
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
    public partial class FormEditarSubasta : Form


    {
        private readonly ISubastaBusiness _subastaBusiness;

        public FormEditarSubasta(ISubastaBusiness subastaBusiness)
        {
            _subastaBusiness = subastaBusiness;
            InitializeComponent();
            CargarMetodosPago1();
            CargarEstadosSubasta();
            CargarSubastas();

        }

        private void CargarMetodosPago1()
        {
            comboBoxMetodosPago.Items.AddRange(Enum.GetNames(typeof(Subasta.MetodosdePago)));
        }
        private void CargarEstadosSubasta()
        {
            comboBoxEstadodeSubasta.Items.AddRange(Enum.GetNames(typeof(Subasta.EstadoSubasta)));
        }

        private async void CargarSubastas()
        {
            var subastasActivas = await _subastaBusiness.GetSubastasActivas();
            var subastasProximas = await _subastaBusiness.GetSubastasProximas();
            var subastasFinalizadas = await _subastaBusiness.GetSubastasFinalizadas();

            var todasSubastas = subastasActivas.Concat(subastasProximas).Concat(subastasFinalizadas).ToList();

            comboBoxTituloSubasta.DataSource = todasSubastas;
            comboBoxTituloSubasta.DisplayMember = "titulo"; // Asegúrate de que la propiedad "titulo" esté en la clase Subasta
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (comboBoxTituloSubasta.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una subasta.");
                return;
            }

            var subastaSeleccionada = (Subasta)comboBoxTituloSubasta.SelectedItem;

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


            var ActualizarSubasta = new Subasta
            {
                titulo = subastaSeleccionada.titulo,
                fechaInicio = fechaInicio,
                fechaFinalizado = fechaFin,
                metodosdePago = metodopago,
                estadoSubasta = estadoSubasta
            };

            var resultado = await _subastaBusiness.UpdateSubasta(ActualizarSubasta);
           

            this.Close();
        }

        private void FormEditarSubasta_Load(object sender, EventArgs e)
        {

        }
    }
}