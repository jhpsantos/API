using Patrimonio.Business.Interface;
using Patrimonio.Entities;
using Patrimonio.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patrimonio.Business
{
    public class MarcaBusiness : IMarcaBusiness
    {
        IMarcaRepository _marcaRepository;

        public MarcaBusiness(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public bool AtualizarMarca(
                int marcaId
            , string nome)
        {
            return _marcaRepository.AtualizarMarca(
                marcaId
                , nome);
        }

        public MarcaEntity ConsultarPorId(int marcaId)
        {
            return _marcaRepository.ConsultarPorId(marcaId);
        }

        public IList<PatrimonioEntity> ConsultarPatrimoniosPorMarcaId(int marcaId)
        {
            return _marcaRepository.ConsultarPatrimoniosPorMarcaId(marcaId);
        }

        public bool ExcluirMarcaPorId(int marcaId)
        {
            return _marcaRepository.ExcluirMarcaPorId(marcaId);
        }

        public bool InserirMarca(string nome)
        {
            return _marcaRepository.InserirMarca(nome);
        }

        public IList<MarcaEntity> ListarTodasMarcas()
        {
            return _marcaRepository.ListarTodasMarcas();
        }
    }
}
