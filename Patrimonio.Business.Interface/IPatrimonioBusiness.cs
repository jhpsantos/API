using Microsoft.Extensions.Options;
using Patrimonio.Entities;
using System;
using System.Collections.Generic;

namespace Patrimonio.Business.Interface
{
    public interface IPatrimonioBusiness
    {

        bool InserirPatrimonio(
            string nome
          , int marcaId
          , string descricao);

        bool AtualizarPatrimonio(
                int patrimonioId
               , string nome
               , int marcaId
               , string descricao);

        bool ExcluirPatrimonioPorId(int patrimonioId);

        bool ExcluirPatrimonioPorNrTombo(string nrTombo);

        IList<PatrimonioEntity> ListarTodosPatrimonios();

        PatrimonioEntity ConsultarPorId(int patrimonioId);

        PatrimonioEntity ConsultarPorNumeroTombo(string nrTombo);
    }
}
