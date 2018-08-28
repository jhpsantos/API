using Patrimonio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patrimonio.Business.Interface
{
    public interface IUsuarioBusiness
    {
        bool InserirUsuario(UsuarioEntity usuario);

        bool AtualizarUsuario(UsuarioEntity usuario);

        bool ExcluirUsuarioPorId(int usuarioID);

        IList<UsuarioEntity> ListarTodosUsuarios();

        UsuarioEntity ConsultarPorId(int usuarioId);
    }
}
