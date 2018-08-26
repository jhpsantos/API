using Dapper;
using Patrimonio.Entities;
using Patrimonio.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patrimonio.Repository.RepositoriosEntidades
{
    public class PatrimonioRepository : IPatrimonioRepository
    {
        public bool AtualizarPatrimonio(PatrimonioObj patrimonio)
        {
            throw new NotImplementedException();
        }

        public PatrimonioObj ConsultarPorId(int patrimonioId)
        {
            throw new NotImplementedException();
        }

        public PatrimonioObj ConsultarPorNumeroTombo(string nrTombo)
        {
            throw new NotImplementedException();
        }

        public bool ExcluirPatrimonio(PatrimonioObj patrimonio)
        {
            throw new NotImplementedException();
        }

        public bool InserirPatrimonio(PatrimonioObj patrimonio)
        {
            throw new NotImplementedException();
        }

        public IList<PatrimonioObj> ListarTodosPatrimonios()
        {
            throw new NotImplementedException();
        }
    }
}
