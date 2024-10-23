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
        public Task<Usuario> AddUsuario(Usuario usuario);
        public Task<Usuario> GetUsuario(int userID);
        public Task<Usuario> UpdateUsuario(Usuario usuario);
        public Task<Usuario> Deleteusuario(int userID);


    }
}