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

        public bool CompareUserToDB(string email);
        public byte[] GetUsuarioHash(string email);
        public byte[] GetUsuarioSalt(string email);
        public bool CreateUser(string email, string password);
        public Usuario ObtainUsuario(string email);




    }
}