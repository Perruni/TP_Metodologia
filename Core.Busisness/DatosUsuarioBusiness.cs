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
       

    }
}
