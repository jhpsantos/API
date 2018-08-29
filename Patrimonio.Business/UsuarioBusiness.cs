using Microsoft.Extensions.Options;
using Patrimonio.Business.Interface;
using Patrimonio.Entities;
using Patrimonio.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patrimonio.Business
{
    public class UsuarioBusiness: IUsuarioBusiness
    {
        IUsuarioRepository _usuarioRepository;

        public UsuarioBusiness(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool AtualizarUsuario(UsuarioEntity usuario)
        {
            return _usuarioRepository.AtualizarUsuario(usuario);
        }

        public UsuarioEntity ConsultarPorId(int usuarioId)
        {
            return _usuarioRepository.ConsultarPorId(usuarioId);
        }

        public bool ExcluirUsuarioPorId(int usuarioId)
        {
            return _usuarioRepository.ExcluirUsuarioPorId(usuarioId);
        }

        public bool InserirUsuario(UsuarioEntity usuario)
        {
            return _usuarioRepository.InserirUsuario(usuario);
        }

        public IList<UsuarioEntity> ListarTodosUsuarios()
        {
            return _usuarioRepository.ListarTodosUsuarios();
        }
    }
}
