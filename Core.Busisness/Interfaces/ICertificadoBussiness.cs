using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness.Interfaces
{
    public interface ICertificadoBussiness
    {
        Certificado ObtenerFacturaPorId(int id);
        List<Certificado> ObtenerTodasLasFacturas();
        void RegistrarFactura(Certificado certificado);
        void EliminarCertificado(int id);
    }
}
