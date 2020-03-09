using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Medico
    {
        public string MedicTipoIdentificacion { get; set; }
        public string MedicIdentificacion { get; set; }
        public string MedicNombre1 { get; set; }
        public string MedicNombre2 { get; set; }
        public string MedicApellido1 { get; set; }
        public string MedicApellido2 { get; set; }
        public byte[] MedicFoto { get; set; }
        public byte[] MedicHuella { get; set; }
        public byte[] MedicFirma { get; set; }
    }
}
