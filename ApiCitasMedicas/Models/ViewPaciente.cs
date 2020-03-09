using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class ViewPaciente
    {
        public string PacTipoIdentificacion { get; set; }
        public string PacIdentificacion { get; set; }
        public string PacNombre1 { get; set; }
        public string PacNombre2 { get; set; }
        public string PacApellido1 { get; set; }
        public string PacApellido2 { get; set; }
        public DateTime PacFechaNacimiento { get; set; }
        public string PacCodGenero { get; set; }
        public string PacCodDepto { get; set; }
        public string PacCodCiudad { get; set; }
        public string PacDireccion { get; set; }
        public int PacCodNivelEducativo { get; set; }
        public string PacCodProfesion { get; set; }
        public int PacTipoSangre { get; set; }
        public int PacEstadoCivil { get; set; }
        public string PacTelefono { get; set; }
        public byte[] PacFoto { get; set; }
        public byte[] PacHuella { get; set; }
        public byte[] PacFirma { get; set; }
        public int PacDominanciaCodigo { get; set; }
        public DateTime? PacFecha { get; set; }
        public int? PacCodEps { get; set; }
        public int? PacCodArl { get; set; }
        public int ArlCodigo { get; set; }
        public string ArlDescripcion { get; set; }
        public int EpsCodigo { get; set; }
        public string EpsDescripcion { get; set; }
        public string CiudCodDepto { get; set; }
        public string CiudCodigo { get; set; }
        public string CiudNombre { get; set; }
        public string DeptCodigo { get; set; }
        public string DeptNombre { get; set; }
    }
}
