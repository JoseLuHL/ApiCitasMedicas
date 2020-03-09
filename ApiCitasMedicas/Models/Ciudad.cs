using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Paciente = new HashSet<Paciente>();
        }

        public string CiudCodDepto { get; set; }
        public string CiudCodigo { get; set; }
        public string CiudNombre { get; set; }

        public virtual Departamento CiudCodDeptoNavigation { get; set; }
        public virtual ICollection<Paciente> Paciente { get; set; }
    }
}
