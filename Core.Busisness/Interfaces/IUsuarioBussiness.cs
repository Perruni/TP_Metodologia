using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness.Interfaces
{
    public interface IUsuarioBussiness
    {
        Usuario ObtenerUsuarioPorId(int id);
        List<Usuario> ObtenerTodosLosUsuarios();
        void RegistrarUsuario(Usuario usuario);
        void EliminarUsuario(int id);


    }
}