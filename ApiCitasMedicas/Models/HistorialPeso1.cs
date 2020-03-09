using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class HistorialPeso1
    {
        public int HistPesCodigo { get; set; }
        public int? HistPesNumeroAtencion { get; set; }
        public string HistPesEdadSobrepeso { get; set; }
        public string HistPesProblema { get; set; }
        public string HistPesPesoMaximo { get; set; }
        public string HistPesPesoMinimo { get; set; }

        public virtual AtencionHistoria HistPesNumeroAtencionNavigation { get; set; }
    }
}
