using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class FrecuenciaConsmo
    {
        public int FreConCodigo { get; set; }
        public int? FreConCodAlimento { get; set; }
        public int? FreConNumeroAtencion { get; set; }
        public string FreConDiario { get; set; }
        public string FreConSemanal { get; set; }
        public string FreConQuincenal { get; set; }
        public string FreConMensual { get; set; }
        public string FreConNunca { get; set; }

        public virtual Alimento FreConCodAlimentoNavigation { get; set; }
        public virtual AtencionHistoria FreConNumeroAtencionNavigation { get; set; }
    }
}
