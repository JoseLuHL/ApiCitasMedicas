using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class TipoSangre
    {
        public TipoSangre()
        {
            Paciente = new HashSet<Paciente>();
        }

        public int TipSanCodigo { get; set; }
        public string TipSanDescripcion { get; set; }

        public virtual ICollection<Paciente> Paciente { get; set; }
    }
}
