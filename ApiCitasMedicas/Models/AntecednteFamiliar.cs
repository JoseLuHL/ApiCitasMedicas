using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class AntecednteFamiliar
    {
        public int AntFamNumero { get; set; }
        public int AntFamEnfermedadCodigo { get; set; }
        public int AntFamEntradaNumero { get; set; }
        public string AntFamParentesco { get; set; }
        public bool AntFamMortalidad { get; set; }

        public virtual AntecedentesF AntFamEnfermedadCodigoNavigation { get; set; }
        public virtual AtencionHistoria AntFamEntradaNumeroNavigation { get; set; }
    }
}
