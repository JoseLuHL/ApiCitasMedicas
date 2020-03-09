using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class AntecedentePersonal
    {
        public int AntPerNumero { get; set; }
        public int AntPerAntecedendeCodigo { get; set; }
        public int AntPerEntradaNumero { get; set; }
        public string AntPerDiagnostico { get; set; }
        public string AntPerObservacion { get; set; }

        public virtual AntecedentesP AntPerAntecedendeCodigoNavigation { get; set; }
        public virtual AtencionHistoria AntPerEntradaNumeroNavigation { get; set; }
    }
}
