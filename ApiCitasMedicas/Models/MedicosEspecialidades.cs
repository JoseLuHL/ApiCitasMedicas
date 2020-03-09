using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class MedicosEspecialidades
    {
        public int Id { get; set; }
        public int Medicoid { get; set; }
        public int Especialidadid { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public bool? Activo { get; set; }

        public virtual Especialidades Especialidad { get; set; }
        public virtual Medicos Medico { get; set; }
    }
}
