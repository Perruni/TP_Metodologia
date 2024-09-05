using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness.Interfaces
{
    public interface IOfertaBussiness
    {
        Oferta ObtenerOfertaPorId(int id);
        List<Oferta> ObtenerTodasLasOfertas();
        void RegistrarOferta(Oferta oferta);
        void EliminarOferta(int id);

    }
}
