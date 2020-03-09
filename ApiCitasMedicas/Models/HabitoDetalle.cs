using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class HabitoDetalle
    {
        public int HabPacHabitoCodigo { get; set; }
        public int HabPacEntradaNumero { get; set; }
        public string HabPacCaracteristica { get; set; }
        public string HabPacFrecuencia { get; set; }
        public string HabPacTiempo { get; set; }
        public string HabPacObservacion { get; set; }

        public virtual AtencionHistoria HabPacEntradaNumeroNavigation { get; set; }
        public virtual Habitos HabPacHabitoCodigoNavigation { get; set; }
    }
}
