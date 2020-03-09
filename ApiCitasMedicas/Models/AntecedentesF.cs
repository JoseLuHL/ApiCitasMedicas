using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class AntecedentesF
    {
        public AntecedentesF()
        {
            AntecednteFamiliar = new HashSet<AntecednteFamiliar>();
        }

        public int AnteFCodigo { get; set; }
        public string AnteFDescripcion { get; set; }

        public virtual ICollection<AntecednteFamiliar> AntecednteFamiliar { get; set; }
    }
}
