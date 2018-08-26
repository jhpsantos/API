using Patrimonio.Entities;
using System;
using System.Collections.Generic;

namespace Patrimonio.Repository.Interface
{
    public interface IPatrimonioRepository 
    {
        bool InserirPatrimonio(PatrimonioObj patrimonio);

        bool AtualizarPatrimonio(PatrimonioObj patrimonio);

        bool ExcluirPatrimonio(PatrimonioObj patrimonio);

        IList<PatrimonioObj> ListarTodosPatrimonios();

        PatrimonioObj ConsultarPorId(int patrimonioId);

        PatrimonioObj ConsultarPorNumeroTombo(string nrTombo);
    }
}
