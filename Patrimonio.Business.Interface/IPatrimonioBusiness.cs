using Patrimonio.Entities;
using System;
using System.Collections.Generic;

namespace Patrimonio.Business.Interface
{
    public interface IPatrimonioBusiness
    {
        bool InserirPatrimonio(PatrimonioEntity patrimonio);

        bool AtualizarPatrimonio(PatrimonioEntity patrimonio);

        bool ExcluirPatrimonioPorId(int patrimonioId);

        bool ExcluirPatrimonioPorNrTombo(string nrTombo);

        IList<PatrimonioEntity> ListarTodosPatrimonios();

        PatrimonioEntity ConsultarPorId(int patrimonioId);

        PatrimonioEntity ConsultarPorNumeroTombo(string nrTombo);
    }
}
