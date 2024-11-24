using Core.Busisness.Interfaces;
using Core.Busisness;
using System.Security.Claims;
using System.Security.Cryptography;
using Core.Data;
using Core.Data.Interface;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Core.Business;


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

        public bool CompareUserToDB(string email)
        {
            return _repository.CompareUserToDB(email);
        }

        public bool CreateUser(string email, string password)
        {
            if (CompareUserToDB(email))
            {
                return false;
            }
            else
            {
                var saltBytes = CryptoHelper.GenerateSalt();

                byte[] hashedPassword = CryptoHelper.HashPassword(password, saltBytes);

                return _repository.CreateUser(email, hashedPassword, saltBytes);
            }
        }

        public Task<Usuario> Deleteusuario(int userID)
        {
            return _repository.Deleteusuario(userID);
        }

        public Task<Usuario> GetUsuario(int userID)
        {
            return _repository.GetUsuario(userID);
        }

        public byte[] GetUsuarioHash(string email)
        {
            return _repository.GetUsuarioHash(email);
        }

        public byte[] GetUsuarioSalt(string email)
        {
            return _repository.GetUsuarioSalt(email);
        }

        public Usuario ObtainUsuario(string email)
        {
            return _repository.ObtainUsuario(email);
        }

        public Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            return _repository.UpdateUsuario(usuario);
        }
    }
}