using Core.Busisness.Interfaces;
using Core.Data.Interface;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness
{

    public class DatosUsuarioBusiness : IDatosUsuarioBusiness
    {
        private readonly IProjectRepository _repository;

        public DatosUsuarioBusiness(IProjectRepository Repository)
        {
            _repository = Repository;
        }

        Task<Datos_usuario> IDatosUsuarioBusiness.AddDatosUsuario(Core.Entities.Datos_usuario datosUsuario)
        {
            return _repository.AddDatosUsuario(datosUsuario);
        }

        Task<Datos_usuario> IDatosUsuarioBusiness.DatosUsuario(int userID)
        {
            return _repository.DatosUsuario(userID);
        }


        
        /*
   private readonly IProyectRepository _facturaRepository;

   public FacturaBusiness(IProyectRepository facturaRepository)
   {
       _facturaRepository = facturaRepository;
   }

   public Factura ObtenerFacturaPorId(int id)
   {
       return _facturaRepository.GetByIdfactura(id);
   }

   public List<Factura> ObtenerTodasLasFacturas()
   {
       return _facturaRepository.GetAllfacturas(); // Utiliza Result y ToList para convertir a sincrónico
   }

   public void RegistrarFactura(Factura factura)
   {
       _facturaRepository.Addfactura(factura);
   }

   public void EliminarFactura(int id)
   {
       _facturaRepository.Deletefactura(id); 
   }*/

    }
}
