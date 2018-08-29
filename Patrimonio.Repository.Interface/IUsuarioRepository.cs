using Microsoft.Extensions.Options;
using Patrimonio.Entities;
using System;
using System.Collections.Generic;

namespace Patrimonio.Repository.Interface
{
    public interface IUsuarioRepository
    {
        bool InserirUsuario(UsuarioEntity usuario);

        bool AtualizarUsuario(UsuarioEntity usuario);

        bool ExcluirUsuarioPorId(int usuarioID);

        IList<UsuarioEntity> ListarTodosUsuarios();

        UsuarioEntity ConsultarPorId(int usuarioId);

        void SetConfiguration(IOptions<AppSettings> config);
    }
}
