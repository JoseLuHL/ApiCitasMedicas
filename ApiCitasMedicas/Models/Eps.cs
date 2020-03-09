using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Eps
    {
        public Eps()
        {
            Paciente = new HashSet<Paciente>();
        }

        public int EpsCodigo { get; set; }
        public string EpsDescripcion { get; set; }

        public virtual ICollection<Paciente> Paciente { get; set; }
    }
}
