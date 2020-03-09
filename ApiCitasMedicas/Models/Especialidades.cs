using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Especialidades
    {
        public Especialidades()
        {
            MedicosEspecialidades = new HashSet<MedicosEspecialidades>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<MedicosEspecialidades> MedicosEspecialidades { get; set; }
    }
}
