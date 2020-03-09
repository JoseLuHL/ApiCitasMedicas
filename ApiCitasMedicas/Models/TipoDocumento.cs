using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Paciente = new HashSet<Paciente>();
        }

        public string TipoIdeCodigo { get; set; }
        public string TipoIdeDescripcion { get; set; }

        public virtual ICollection<Paciente> Paciente { get; set; }
    }
}
