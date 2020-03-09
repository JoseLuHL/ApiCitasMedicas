using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Pacientes
    {
        public Pacientes()
        {
            Citas = new HashSet<Citas>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Citas> Citas { get; set; }
    }
}
