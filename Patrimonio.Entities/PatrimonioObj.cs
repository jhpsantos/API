using System;
using System.Runtime.Serialization;

namespace Patrimonio.Entities
{
    [Serializable]
    public class PatrimonioObj
    {
        [DataMember]
        public int PatrimonioId { get; set; }

        [DataMember]
        public string NrTombo { get; set; }

        [DataMember]
        public string Nome { get; set; }

        [DataMember]
        public int MarcaId { get; set; }

        [DataMember]
        public string Descricao { get; set; }
    }
}
