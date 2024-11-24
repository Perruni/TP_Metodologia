using Core.Busisness.Interfaces;
using Core.Data;
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
        public FormDetallesOfertantes(TPI_DbContext context, ISubastaBusiness subastaBusiness)
        {
            
            _context = context;
            _subastaBusiness = subastaBusiness;
            InitializeComponent();
            
        }


        private void FormDetallesOfertantes_Load(object sender, EventArgs e)
        {
           
            var productos = _context.Productos
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

           
            dataGridViewProductos.DataSource = productos;
            dataGridViewProductos.Columns["productoID"].Visible = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                var productoId = (int)dataGridViewProductos.Rows[e.RowIndex].Cells["productoID"].Value;


                var ofertantes = _context.Ofertas
                    .Where(o => o.productoID == productoId && Enum.IsDefined(typeof(EstadoOferta), o.estadoOferta))
                    .Include(o => o.usuario)
                    .Select(o => new
                    {
                        ofertaID = o.ofertaID,
                        montoOferta = o.montoOferta,
                        fechaOferta = o.fechaOferta,
                        usuarioID = o.usuario.usuarioID,                    
                        usuario = o.usuario
                    })
                    .ToList();


                dataGridViewProductos.Rows[e.RowIndex].Selected = true;
                dataGridViewOfertantes.DataSource = ofertantes;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
