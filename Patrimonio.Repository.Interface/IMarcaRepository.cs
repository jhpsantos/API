using Microsoft.Extensions.Options;
using Patrimonio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patrimonio.Repository.Interface
{
    public interface IMarcaRepository
    {
        bool InserirMarca(string nome);

        bool AtualizarMarca(
                int marcaId
            , string nome);

        bool ExcluirMarcaPorId(int marcaID);

        IList<MarcaEntity> ListarTodasMarcas();


        MarcaEntity ConsultarPorId(int marcaId);

        IList<PatrimonioEntity> ConsultarPatrimoniosPorMarcaId(int marcaId);
    }
}
