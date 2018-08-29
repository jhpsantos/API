using Dapper;
using Microsoft.Extensions.Configuration;
using Patrimonio.Entities;
using Patrimonio.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Patrimonio.Repository.RepositoriosEntidades
{
    public class MarcaRepository: Base , IMarcaRepository
    {
        bool disposed = false;

        public MarcaRepository(IConfiguration settings)
        {
           connection = 
                new SqlConnection(settings.GetSection("ApplicationSettings").GetSection("ConnectionString").Value);
        }

        public bool InserirMarca(string nome)
        {
            bool retorno = false;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Nome", nome);
                int linhasAfetadas = SqlMapper.Execute(
                    connection
                    , "USP_Inserir_Marca"
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

        public bool AtualizarMarca(
                int marcaId
            ,   string nome)
        {
            bool retorno = false;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MarcaId", marcaId);
                parameters.Add("@Nome", nome);
                int linhasAfetadas = SqlMapper.Execute(
                    connection
                    , "USP_Atualizar_Marca"
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

        public bool ExcluirMarcaPorId(int marcaID)
        {
            bool retorno = false;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MarcaID", marcaID);

                int linhasAfetadas = SqlMapper.Execute(
                    connection
                    , "USP_Excluir_Marca_Por_ID"
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

        public IList<MarcaEntity> ListarTodasMarcas()
        {
            IList<MarcaEntity> usuarios;

            try
            {
                usuarios
                      = SqlMapper.Query<MarcaEntity>(
                      connection
                      , "USP_Listar_Marcas"
                      , CommandType.StoredProcedure).AsList<MarcaEntity>();
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return usuarios;
        }

        public MarcaEntity ConsultarPorId(int marcaId)
        {
            MarcaEntity retorno = null;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MarcaId", marcaId);

                retorno = SqlMapper.QueryFirstOrDefault<MarcaEntity>(
                    connection
                    , "USP_Consultar_Marca_Por_ID"
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

        public IList<PatrimonioEntity> ConsultarPatrimoniosPorMarcaId(int marcaId)
        {
            IList<PatrimonioEntity> patrimonios = null;

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MarcaId", marcaId);

                patrimonios = SqlMapper.Query<PatrimonioEntity>(
                    connection
                    , "USP_Consultar_Patrimonios_Por_Marca_ID"
                    , parameters
                    , null
                    , false
                    , null
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

            return patrimonios;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;

            disposed = true;

            base.Dispose(disposing);
        }

        ~MarcaRepository()
        {
            Dispose(false);
        }

    }
}
