using System;
using System.Runtime.Serialization;

namespace Patrimonio.Entities
{
    public class PatrimonioEntity
    {
        public int PatrimonioId { get; set; }

        public string NrTombo { get; set; }

        public string Nome { get; set; }

        public int MarcaId { get; set; }

        public string Descricao { get; set; }
    }
}
