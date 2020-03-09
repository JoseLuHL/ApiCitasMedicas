using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Arl
    {
        public Arl()
        {
            Paciente = new HashSet<Paciente>();
        }

        public int ArlCodigo { get; set; }
        public string ArlDescripcion { get; set; }

        public virtual ICollection<Paciente> Paciente { get; set; }
    }
}
