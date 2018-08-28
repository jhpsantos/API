using Dapper;
using Patrimonio.Entities;
using Patrimonio.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Patrimonio.Repository.RepositoriosEntidades
{
    public class UsuarioRepository: Base, IUsuarioRepository
    {
        bool disposed = false;

        public bool AtualizarUsuario(UsuarioEntity usuario)
        {
            bool retorno = false;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UsuarioId", usuario.UsuarioId);
                parameters.Add("@Nome", usuario.Nome);
                parameters.Add("@Email", usuario.Email);
                parameters.Add("@Senha", usuario.Senha);
                int linhasAfetadas = SqlMapper.Execute(
                    connection
                    , "USP_Atualizar_Usuario"
                    , parameters
                    , null
                    , null
                    , CommandType.StoredProcedure);

                ///Se não retornou linhas afetadas a inserção,
                ///deverá retornar falso;
                retorno = (!linhasAfetadas.Equals(0));
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public UsuarioEntity ConsultarPorId(int usuarioId)
        {
            UsuarioEntity retorno = null;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UsuarioId", usuarioId);

                retorno = SqlMapper.QueryFirstOrDefault<UsuarioEntity>(
                    connection
                    , "USP_Consultar_Usuario_Por_ID"
                    , parameters
                    , null
                    , null
                    , CommandType.StoredProcedure);
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public bool ExcluirUsuarioPorId(int usuarioID)
        {
            bool retorno = false;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UsuarioId", usuarioID);

                int linhasAfetadas = SqlMapper.Execute(
                    connection
                    , "USP_Excluir_Usuario_Por_ID"
                    , parameters
                    , null
                    , null
                    , CommandType.StoredProcedure);

                ///Se não retornou linhas afetadas a exclusão,
                ///deverá retornar falso;
                retorno = (!linhasAfetadas.Equals(0));

            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }
        
        public bool InserirUsuario(UsuarioEntity usuario)
        {
            bool retorno = false;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Nome", usuario.Nome);
                parameters.Add("@Email", usuario.Email);
                parameters.Add("@Senha", usuario.Senha);
                int linhasAfetadas = SqlMapper.Execute(
                    connection
                    , "USP_Inserir_Usuario"
                    , parameters
                    , null
                    , null
                    , CommandType.StoredProcedure);

                ///Se não retornou linhas afetadas a inserção,
                ///deverá retornar falso;
                retorno = (!linhasAfetadas.Equals(0));
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retorno;
        }

        public IList<UsuarioEntity> ListarTodosUsuarios()
        {
            IList<UsuarioEntity> resultado;

            try
            {
                resultado
                      = SqlMapper.Query<UsuarioEntity>(
                      connection
                      , "USP_Listar_Usuarios"
                      , CommandType.StoredProcedure).AsList<UsuarioEntity>();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            disposed = true;

            base.Dispose(disposing);
        }

        ~UsuarioRepository()
        {
            Dispose(false);
        }
    }
}
