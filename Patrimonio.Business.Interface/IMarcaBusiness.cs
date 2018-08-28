using Patrimonio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patrimonio.Business.Interface
{
    public interface IMarcaBusiness
    {
        bool AtualizarMarca(
                int marcaId
            , string nome);

        MarcaEntity ConsultarPorId(int marcaId);

        IList<PatrimonioEntity> ConsultarPatrimoniosPorMarcaId(int marcaId);

        bool ExcluirMarcaPorId(int marcaId);

        bool InserirMarca(string nome);

        IList<MarcaEntity> ListarTodasMarcas();
    }
}
