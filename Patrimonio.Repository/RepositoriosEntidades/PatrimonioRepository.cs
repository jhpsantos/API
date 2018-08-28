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
    public class PatrimonioRepository : Base, IPatrimonioRepository
    {
        bool disposed = false;

        public bool AtualizarPatrimonio(PatrimonioEntity patrimonio)
        {
            bool retorno = false;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PatrimonioId", patrimonio.PatrimonioId);
                parameters.Add("@Nome", patrimonio.Nome);
                parameters.Add("@MarcaId", patrimonio.MarcaId);
                parameters.Add("@Descricao", patrimonio.Descricao);
                int linhasAfetadas = SqlMapper.Execute(
                    connection
                    , "USP_Atualizar_Patrimonio"
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

        public PatrimonioEntity ConsultarPorId(int patrimonioId)
        {
            PatrimonioEntity retorno = null;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PatrimonioId", patrimonioId);

                retorno = SqlMapper.QueryFirstOrDefault<PatrimonioEntity>(
                    connection
                    , "USP_Consultar_Patrimonio_Por_ID"
                    , parameters
                    , null
                    , null
                    , CommandType.StoredProcedure);

                if (null == retorno
                    || retorno.PatrimonioId.Equals(0))
                    throw new Exception(
                        string.Format(@"Ocorreu um erro ao consultar por ID '{0}'. Registro não encontrado!"
                        , patrimonioId));
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

        public PatrimonioEntity ConsultarPorNumeroTombo(string nrTombo)
        {
            PatrimonioEntity retorno = null;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NrTombo", nrTombo);

                retorno = SqlMapper.QueryFirstOrDefault<PatrimonioEntity>(
                    connection
                    , "USP_Consultar_Por_NrTombo"
                    , parameters
                    , null
                    , null
                    , CommandType.StoredProcedure);

                if (null == retorno
                    || retorno.PatrimonioId.Equals(0))
                    throw new Exception(
                        string.Format(@"Ocorreu um erro ao consultar por Nr.Tombo '{0}'. Registro não encontrado!"
                        , nrTombo));
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

        public bool ExcluirPatrimonioPorId(int patrimonioID)
        {
            bool retorno = false;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PatrimonioID", patrimonioID);

                int linhasAfetadas = SqlMapper.Execute(
                    connection
                    , "USP_Excluir_Patrimonio_Por_ID"
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

        public bool ExcluirPatrimonioPorNrTombo(string nrTombo)
        {
            bool retorno = false;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@NrTombo", nrTombo);

                int linhasAfetadas = SqlMapper.Execute(
                    connection
                    , "USP_Excluir_Patrimonio_Por_NrTombo"
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

        public bool InserirPatrimonio(PatrimonioEntity patrimonio)
        {
            bool retorno = false;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Nome", patrimonio.Nome);
                parameters.Add("@MarcaId", patrimonio.MarcaId);
                parameters.Add("@Descricao", patrimonio.Descricao);
                int linhasAfetadas = SqlMapper.Execute(
                    connection
                    , "USP_Inserir_Patrimonio"
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

        public IList<PatrimonioEntity> ListarTodosPatrimonios()
        {
            IList<PatrimonioEntity> resultado;

            try
            {
                resultado
                      = SqlMapper.Query<PatrimonioEntity>(
                      connection
                      , "USP_Listar_Patrimonios"
                      , CommandType.StoredProcedure).AsList<PatrimonioEntity>();
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

        ~PatrimonioRepository()
        {
            Dispose(false);
        }
    }
}
