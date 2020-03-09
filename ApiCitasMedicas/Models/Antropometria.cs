using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Antropometria
    {
        public int AntrCodigo { get; set; }
        public int? AntrNumeroAtencion { get; set; }
        public string AntrPeso { get; set; }
        public string AntrTalla { get; set; }
        public string AntrImc { get; set; }
        public string AntrPesoIdeal { get; set; }
        public string AntrExcesoPeso { get; set; }

        public virtual AtencionHistoria AntrNumeroAtencionNavigation { get; set; }
    }
}
