using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Alimento
    {
        public Alimento()
        {
            FrecuenciaConsmo = new HashSet<FrecuenciaConsmo>();
        }

        public int AlimCodigo { get; set; }
        public string AlimDescripcion { get; set; }

        public virtual ICollection<FrecuenciaConsmo> FrecuenciaConsmo { get; set; }
    }
}
