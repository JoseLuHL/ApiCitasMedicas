using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public int? Medicoid { get; set; }
        public bool? Activo { get; set; }
    }
}
