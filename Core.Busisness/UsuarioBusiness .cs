using Core.Busisness.Interfaces;

using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Busisness
{
    /*public class UsuarioBusiness : IUsuarioBussiness
    {
        private readonly IRepository _Repository;

        public UsuarioBusiness(IRepository usuarioRepository)
        {
            _Repository = usuarioRepository;
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return _Repository.ObtenerUsuarioPorId(id);
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return _Repository.ObtenerTodosLosUsuarios();
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            _Repository.RegistrarUsuario(usuario);
        }

        public void EliminarUsuario(int id)
        {
            _Repository.EliminarUsuario(id);
        }

        public bool ValidarUsuarioAdmin(int id)
        {
            var usuario = _Repository.ObtenerUsuarioPorId(id);
            if (usuario.roles == 1)
            {
                return true;
            }
            return false;
        }
    }*/
}