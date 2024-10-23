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
    public class UsuarioBusiness : IUsuarioBussiness
    {

        private readonly IProjectRepository _repository;

        public UsuarioBusiness(IProjectRepository Repository)
        {
            _repository = Repository;
        }

        public Task<Usuario> AddUsuario(Usuario usuario)
        {
            return _repository.AddUsuario(usuario);
        }

        public Task<Usuario> Deleteusuario(int userID)
        {
            return _repository.Deleteusuario(userID);
        }

        public Task<Usuario> GetUsuario(int userID)
        {
            return _repository.GetUsuario(userID);
        }

        public Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            return _repository.UpdateUsuario(usuario);
        }
    }
}