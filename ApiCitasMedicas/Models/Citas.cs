using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Citas
    {
        public int Id { get; set; }
        public int Medicoid { get; set; }
        public int Pacienteid { get; set; }
        public DateTime Fechaatencion { get; set; }
        public string Inicioatencion { get; set; }
        public string Finatencion { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public bool? Activo { get; set; }
        public DateTime Fecharegistro { get; set; }

        public virtual Medicos Medico { get; set; }
        public virtual Pacientes Paciente { get; set; }
    }
}
