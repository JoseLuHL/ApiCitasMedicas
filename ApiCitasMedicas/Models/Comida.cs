using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Comida
    {
        public Comida()
        {
            Recordatorio = new HashSet<Recordatorio>();
        }

        public int ComdCodigo { get; set; }
        public string ComdDescripcion { get; set; }

        public virtual ICollection<Recordatorio> Recordatorio { get; set; }
    }
}
