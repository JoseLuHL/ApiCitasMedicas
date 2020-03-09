using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Medicos
    {
        public Medicos()
        {
            Citas = new HashSet<Citas>();
            Horarios = new HashSet<Horarios>();
            MedicosEspecialidades = new HashSet<MedicosEspecialidades>();
        }

        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public string Numcolegiatura { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Citas> Citas { get; set; }
        public virtual ICollection<Horarios> Horarios { get; set; }
        public virtual ICollection<MedicosEspecialidades> MedicosEspecialidades { get; set; }
    }
}
