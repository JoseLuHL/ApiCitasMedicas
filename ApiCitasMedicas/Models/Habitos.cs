using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Habitos
    {
        public Habitos()
        {
            HabitoDetalle = new HashSet<HabitoDetalle>();
        }

        public int HabCodigo { get; set; }
        public string HabDescripcion { get; set; }

        public virtual ICollection<HabitoDetalle> HabitoDetalle { get; set; }
    }
}
