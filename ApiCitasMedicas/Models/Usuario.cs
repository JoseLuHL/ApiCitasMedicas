using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioModulo = new HashSet<UsuarioModulo>();
        }

        public string UsuNombre { get; set; }
        public string UsuContraseña { get; set; }
        public string UsuNombreCompleto { get; set; }
        public DateTime? UsuFechaCaduca { get; set; }
        public string UsuEstado { get; set; }
        public string UsuTipo { get; set; }

        public virtual ICollection<UsuarioModulo> UsuarioModulo { get; set; }
    }
}
