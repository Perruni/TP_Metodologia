using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness.Interfaces
{
    public interface IFacturaBussiness
    {
        Factura ObtenerFacturaPorId(int id);
        List<Factura> ObtenerTodasLasFacturas();
        void RegistrarFactura(Factura factura);
        void EliminarFactura(int id);
    }
}
