using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Ciudad = new HashSet<Ciudad>();
        }

        public string DeptCodigo { get; set; }
        public string DeptNombre { get; set; }

        public virtual ICollection<Ciudad> Ciudad { get; set; }
    }
}
