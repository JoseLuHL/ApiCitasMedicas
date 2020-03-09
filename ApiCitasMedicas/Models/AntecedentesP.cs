using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class AntecedentesP
    {
        public AntecedentesP()
        {
            AntecedentePersonal = new HashSet<AntecedentePersonal>();
        }

        public int AntePCodigo { get; set; }
        public string AntePDescripcion { get; set; }

        public virtual ICollection<AntecedentePersonal> AntecedentePersonal { get; set; }
    }
}
