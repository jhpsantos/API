﻿using Patrimonio.Business.Interface;
using Patrimonio.Entities;
using Patrimonio.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Patrimonio.Business
{
    public class PatrimonioBusiness : IPatrimonioBusiness
    {
        IPatrimonioRepository _patrimonioRepository;

        public PatrimonioBusiness(IPatrimonioRepository patrimonioRepository)
        {
            _patrimonioRepository = patrimonioRepository;
        }

        public bool AtualizarPatrimonio(PatrimonioEntity patrimonio)
        {
            return _patrimonioRepository.AtualizarPatrimonio(patrimonio);
        }

        public PatrimonioEntity ConsultarPorId(int patrimonioId)
        {
            return _patrimonioRepository.ConsultarPorId(patrimonioId);
        }

        public PatrimonioEntity ConsultarPorNumeroTombo(string nrTombo)
        {
            return _patrimonioRepository.ConsultarPorNumeroTombo(nrTombo);
        }

        public bool ExcluirPatrimonioPorId(int patrimonioId)
        {
            return _patrimonioRepository.ExcluirPatrimonioPorId(patrimonioId);
        }

        public bool ExcluirPatrimonioPorNrTombo(string nrTombo)
        {
            return _patrimonioRepository.ExcluirPatrimonioPorNrTombo(nrTombo);
        }

        public bool InserirPatrimonio(PatrimonioEntity patrimonio)
        {
            return _patrimonioRepository.InserirPatrimonio(patrimonio);
        }

        public IList<PatrimonioEntity> ListarTodosPatrimonios()
        {
            return _patrimonioRepository.ListarTodosPatrimonios();
        }
    }
}
