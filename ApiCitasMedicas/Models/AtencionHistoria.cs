using System;
using System.Collections.Generic;

namespace ApiCitasMedicas.Models
{
    public partial class AtencionHistoria
    {
        public AtencionHistoria()
        {
            AntecedentePersonal = new HashSet<AntecedentePersonal>();
            AntecednteFamiliar = new HashSet<AntecednteFamiliar>();
            Antropometria = new HashSet<Antropometria>();
            FrecuenciaConsmo = new HashSet<FrecuenciaConsmo>();
            HabitoDetalle = new HashSet<HabitoDetalle>();
            HistorialPeso1 = new HashSet<HistorialPeso1>();
            Recordatorio = new HashSet<Recordatorio>();
        }

        public int EntrNumero { get; set; }
        public string EntrIdPaciente { get; set; }
        public DateTime EntrFechaEntrada { get; set; }
        public TimeSpan? EntrHora { get; set; }
        public string EntrDiagnostico { get; set; }
        public int EntrConceptoCodigo { get; set; }
        public string EntrRecomendacion { get; set; }
        public bool EntrReubicacion { get; set; }
        public int? EntrTipoExamenCodigo { get; set; }
        public int? EntEnfasis { get; set; }
        public int? EntEstado { get; set; }
        public string EntConceptoAptitud { get; set; }
        public int? EntCodEps { get; set; }
        public int? EntCodArl { get; set; }
        public string EntMotivoConsulta { get; set; }
        public string EntCodMedico { get; set; }

        public virtual ICollection<AntecedentePersonal> AntecedentePersonal { get; set; }
        public virtual ICollection<AntecednteFamiliar> AntecednteFamiliar { get; set; }
        public virtual ICollection<Antropometria> Antropometria { get; set; }
        public virtual ICollection<FrecuenciaConsmo> FrecuenciaConsmo { get; set; }
        public virtual ICollection<HabitoDetalle> HabitoDetalle { get; set; }
        public virtual ICollection<HistorialPeso1> HistorialPeso1 { get; set; }
        public virtual ICollection<Recordatorio> Recordatorio { get; set; }
    }
}
