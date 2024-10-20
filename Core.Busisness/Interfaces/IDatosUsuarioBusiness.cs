using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness.Interfaces
{
    public interface IDatosUsuarioBusiness
    {
        public Task<Datos_usuario> DatosUsuario(int userID);
        public Task<Datos_usuario> AddDatosUsuario(Datos_usuario datosUsuario);


    }
}
