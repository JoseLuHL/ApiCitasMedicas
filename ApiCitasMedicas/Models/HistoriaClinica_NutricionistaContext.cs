using System;
using ApiCitasMedicas.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiCitasMedicas.Models
{
    public partial class HistoriaClinica_NutricionistaContext : DbContext
    {
        public HistoriaClinica_NutricionistaContext(DbContextOptions<HistoriaClinica_NutricionistaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alimento> Alimento { get; set; }
        public virtual DbSet<AntecedentePersonal> AntecedentePersonal { get; set; }
        public virtual DbSet<AntecedentesF> AntecedentesF { get; set; }
        public virtual DbSet<AntecedentesP> AntecedentesP { get; set; }
        public virtual DbSet<AntecednteFamiliar> AntecednteFamiliar { get; set; }
        public virtual DbSet<Antropometria> Antropometria { get; set; }
        public virtual DbSet<Arl> Arl { get; set; }
        public virtual DbSet<AtencionHistoria> AtencionHistoria { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Comida> Comida { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Dominancia> Dominancia { get; set; }
        public virtual DbSet<Eps> Eps { get; set; }
        public virtual DbSet<Especialidades> Especialidades { get; set; }
        public virtual DbSet<EstadoAtencion> EstadoAtencion { get; set; }
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }
        public virtual DbSet<FrecuenciaConsmo> FrecuenciaConsmo { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<HabitoDetalle> HabitoDetalle { get; set; }
        public virtual DbSet<Habitos> Habitos { get; set; }
        public virtual DbSet<HistorialPeso> HistorialPeso { get; set; }
        public virtual DbSet<HistorialPeso1> HistorialPeso1 { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<Medico> Medico { get; set; }
        public virtual DbSet<Medicos> Medicos { get; set; }
        public virtual DbSet<MedicosEspecialidades> MedicosEspecialidades { get; set; }
        public virtual DbSet<NivelEducativo> NivelEducativo { get; set; }
        public virtual DbSet<Ocupacion> Ocupacion { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<Profesion> Profesion { get; set; }
        public virtual DbSet<Recordatorio> Recordatorio { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoSangre> TipoSangre { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioModulo> UsuarioModulo { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<ViewPaciente> ViewPaciente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alimento>(entity =>
            {
                entity.HasKey(e => e.AlimCodigo);

                entity.Property(e => e.AlimCodigo).HasColumnName("Alim_Codigo");

                entity.Property(e => e.AlimDescripcion)
                    .HasColumnName("Alim_Descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AntecedentePersonal>(entity =>
            {
                entity.HasKey(e => e.AntPerNumero);

                entity.Property(e => e.AntPerNumero).HasColumnName("AntPer_Numero");

                entity.Property(e => e.AntPerAntecedendeCodigo).HasColumnName("AntPer_Antecedende_Codigo");

                entity.Property(e => e.AntPerDiagnostico)
                    .IsRequired()
                    .HasColumnName("AntPer_Diagnostico")
                    .HasMaxLength(500);

                entity.Property(e => e.AntPerEntradaNumero).HasColumnName("AntPer_Entrada_Numero");

                entity.Property(e => e.AntPerObservacion)
                    .HasColumnName("AntPer_Observacion")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AntPerAntecedendeCodigoNavigation)
                    .WithMany(p => p.AntecedentePersonal)
                    .HasForeignKey(d => d.AntPerAntecedendeCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AntecedentePersonal_AntecedentesP");

                entity.HasOne(d => d.AntPerEntradaNumeroNavigation)
                    .WithMany(p => p.AntecedentePersonal)
                    .HasForeignKey(d => d.AntPerEntradaNumero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AntecedentePersonal_Atencion_Historia");
            });

            modelBuilder.Entity<AntecedentesF>(entity =>
            {
                entity.HasKey(e => e.AnteFCodigo);

                entity.Property(e => e.AnteFCodigo)
                    .HasColumnName("AnteF_Codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.AnteFDescripcion)
                    .HasColumnName("AnteF_Descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AntecedentesP>(entity =>
            {
                entity.HasKey(e => e.AntePCodigo);

                entity.Property(e => e.AntePCodigo)
                    .HasColumnName("AnteP_Codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.AntePDescripcion)
                    .HasColumnName("AnteP_Descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AntecednteFamiliar>(entity =>
            {
                entity.HasKey(e => e.AntFamNumero);

                entity.Property(e => e.AntFamNumero).HasColumnName("AntFam_Numero");

                entity.Property(e => e.AntFamEnfermedadCodigo).HasColumnName("AntFam_Enfermedad_Codigo");

                entity.Property(e => e.AntFamEntradaNumero).HasColumnName("AntFam_Entrada_Numero");

                entity.Property(e => e.AntFamMortalidad).HasColumnName("AntFam_Mortalidad");

                entity.Property(e => e.AntFamParentesco)
                    .IsRequired()
                    .HasColumnName("AntFam_Parentesco")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AntFamEnfermedadCodigoNavigation)
                    .WithMany(p => p.AntecednteFamiliar)
                    .HasForeignKey(d => d.AntFamEnfermedadCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AntecednteFamiliar_AntecedentesF");

                entity.HasOne(d => d.AntFamEntradaNumeroNavigation)
                    .WithMany(p => p.AntecednteFamiliar)
                    .HasForeignKey(d => d.AntFamEntradaNumero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AntecednteFamiliar_Atencion_Historia");
            });

            modelBuilder.Entity<Antropometria>(entity =>
            {
                entity.HasKey(e => e.AntrCodigo);

                entity.Property(e => e.AntrCodigo).HasColumnName("Antr_Codigo");

                entity.Property(e => e.AntrExcesoPeso)
                    .HasColumnName("Antr_ExcesoPeso")
                    .HasMaxLength(50);

                entity.Property(e => e.AntrImc)
                    .HasColumnName("Antr_IMC")
                    .HasMaxLength(50);

                entity.Property(e => e.AntrNumeroAtencion).HasColumnName("Antr__NumeroAtencion");

                entity.Property(e => e.AntrPeso)
                    .HasColumnName("Antr_Peso")
                    .HasMaxLength(50);

                entity.Property(e => e.AntrPesoIdeal)
                    .HasColumnName("Antr_PesoIdeal")
                    .HasMaxLength(50);

                entity.Property(e => e.AntrTalla)
                    .HasColumnName("Antr_Talla")
                    .HasMaxLength(50);

                entity.HasOne(d => d.AntrNumeroAtencionNavigation)
                    .WithMany(p => p.Antropometria)
                    .HasForeignKey(d => d.AntrNumeroAtencion)
                    .HasConstraintName("FK_Antropometria_Atencion_Historia");
            });

            modelBuilder.Entity<Arl>(entity =>
            {
                entity.HasKey(e => e.ArlCodigo);

                entity.ToTable("ARL");

                entity.Property(e => e.ArlCodigo).HasColumnName("Arl_Codigo");

                entity.Property(e => e.ArlDescripcion)
                    .IsRequired()
                    .HasColumnName("Arl_Descripcion")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<AtencionHistoria>(entity =>
            {
                entity.HasKey(e => e.EntrNumero)
                    .HasName("PK_EntradaHistoria");

                entity.ToTable("Atencion_Historia");

                entity.Property(e => e.EntrNumero).HasColumnName("Entr_Numero");

                entity.Property(e => e.EntCodArl).HasColumnName("Ent_CodARL");

                entity.Property(e => e.EntCodEps).HasColumnName("Ent_CodEPS");

                entity.Property(e => e.EntCodMedico)
                    .HasColumnName("Ent_CodMedico")
                    .HasMaxLength(10);

                entity.Property(e => e.EntConceptoAptitud)
                    .HasColumnName("Ent_conceptoAptitud")
                    .HasMaxLength(256);

                entity.Property(e => e.EntEnfasis).HasColumnName("Ent_Enfasis");

                entity.Property(e => e.EntEstado).HasColumnName("Ent_Estado");

                entity.Property(e => e.EntMotivoConsulta)
                    .HasColumnName("Ent_MotivoConsulta")
                    .HasMaxLength(500);

                entity.Property(e => e.EntrConceptoCodigo).HasColumnName("Entr_Concepto_Codigo");

                entity.Property(e => e.EntrDiagnostico)
                    .IsRequired()
                    .HasColumnName("Entr_Diagnostico")
                    .HasMaxLength(5);

                entity.Property(e => e.EntrFechaEntrada)
                    .HasColumnName("Entr_FechaEntrada")
                    .HasColumnType("date");

                entity.Property(e => e.EntrHora).HasColumnName("Entr_Hora");

                entity.Property(e => e.EntrIdPaciente)
                    .IsRequired()
                    .HasColumnName("Entr_IdPaciente")
                    .HasMaxLength(10);

                entity.Property(e => e.EntrRecomendacion)
                    .HasColumnName("Entr_Recomendacion")
                    .HasMaxLength(200);

                entity.Property(e => e.EntrReubicacion).HasColumnName("Entr_Reubicacion");

                entity.Property(e => e.EntrTipoExamenCodigo).HasColumnName("Entr_TipoExamenCodigo");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.CargCodigo);

                entity.Property(e => e.CargCodigo).HasColumnName("Carg_Codigo");

                entity.Property(e => e.CargDescripcion)
                    .IsRequired()
                    .HasColumnName("Carg_Descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Citas>(entity =>
            {
                entity.ToTable("CITAS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Fechaatencion)
                    .HasColumnName("FECHAATENCION")
                    .HasColumnType("date");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Finatencion).HasColumnName("FINATENCION");

                entity.Property(e => e.Inicioatencion).HasColumnName("INICIOATENCION");

                entity.Property(e => e.Medicoid).HasColumnName("MEDICOID");

                entity.Property(e => e.Observaciones)
                    .HasColumnName("OBSERVACIONES")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Pacienteid).HasColumnName("PACIENTEID");

                entity.HasOne(d => d.Medico)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.Medicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDICOS_CITAS");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Citas)
                    .HasForeignKey(d => d.Pacienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PACIENTES_CITAS");
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => new { e.CiudCodDepto, e.CiudCodigo })
                    .HasName("PK_Table1");

                entity.Property(e => e.CiudCodDepto)
                    .HasColumnName("Ciud_CodDepto")
                    .HasMaxLength(2);

                entity.Property(e => e.CiudCodigo)
                    .HasColumnName("Ciud_Codigo")
                    .HasMaxLength(3);

                entity.Property(e => e.CiudNombre)
                    .IsRequired()
                    .HasColumnName("Ciud_Nombre")
                    .HasMaxLength(25);

                entity.HasOne(d => d.CiudCodDeptoNavigation)
                    .WithMany(p => p.Ciudad)
                    .HasForeignKey(d => d.CiudCodDepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciudad_Departamento");
            });

            modelBuilder.Entity<Comida>(entity =>
            {
                entity.HasKey(e => e.ComdCodigo);

                entity.Property(e => e.ComdCodigo).HasColumnName("Comd_Codigo");

                entity.Property(e => e.ComdDescripcion)
                    .HasColumnName("Comd_Descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.DeptCodigo);

                entity.Property(e => e.DeptCodigo)
                    .HasColumnName("Dept_Codigo")
                    .HasMaxLength(2);

                entity.Property(e => e.DeptNombre)
                    .IsRequired()
                    .HasColumnName("Dept_Nombre")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Dominancia>(entity =>
            {
                entity.HasKey(e => e.DomCodigo);

                entity.Property(e => e.DomCodigo).HasColumnName("Dom_Codigo");

                entity.Property(e => e.DomDescripcion)
                    .IsRequired()
                    .HasColumnName("Dom_Descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Eps>(entity =>
            {
                entity.HasKey(e => e.EpsCodigo);

                entity.ToTable("EPS");

                entity.Property(e => e.EpsCodigo).HasColumnName("Eps_Codigo");

                entity.Property(e => e.EpsDescripcion)
                    .IsRequired()
                    .HasColumnName("Eps_Descripcion")
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Especialidades>(entity =>
            {
                entity.ToTable("ESPECIALIDADES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("DESCRIPCION")
                    .HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoAtencion>(entity =>
            {
                entity.HasKey(e => e.EstAtenCodigo);

                entity.ToTable("Estado_Atencion");

                entity.Property(e => e.EstAtenCodigo)
                    .HasColumnName("EstAten_Codigo")
                    .ValueGeneratedNever();

                entity.Property(e => e.EstAtenDescripcion)
                    .HasColumnName("EstAten_Descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.HasKey(e => e.EstCivilCodigo);

                entity.Property(e => e.EstCivilCodigo).HasColumnName("EstCivil_Codigo");

                entity.Property(e => e.EstCivilDescripcion)
                    .IsRequired()
                    .HasColumnName("EstCivil_Descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FrecuenciaConsmo>(entity =>
            {
                entity.HasKey(e => e.FreConCodigo);

                entity.ToTable("Frecuencia_Consmo");

                entity.Property(e => e.FreConCodigo).HasColumnName("FreCon_Codigo");

                entity.Property(e => e.FreConCodAlimento).HasColumnName("FreCon_CodAlimento");

                entity.Property(e => e.FreConDiario)
                    .HasColumnName("FreCon_Diario")
                    .HasMaxLength(50);

                entity.Property(e => e.FreConMensual)
                    .HasColumnName("FreCon_Mensual")
                    .HasMaxLength(50);

                entity.Property(e => e.FreConNumeroAtencion).HasColumnName("FreCon_NumeroAtencion");

                entity.Property(e => e.FreConNunca)
                    .HasColumnName("FreCon_Nunca")
                    .HasMaxLength(50);

                entity.Property(e => e.FreConQuincenal)
                    .HasColumnName("FreCon_Quincenal")
                    .HasMaxLength(50);

                entity.Property(e => e.FreConSemanal)
                    .HasColumnName("FreCon_Semanal")
                    .HasMaxLength(50);

                entity.HasOne(d => d.FreConCodAlimentoNavigation)
                    .WithMany(p => p.FrecuenciaConsmo)
                    .HasForeignKey(d => d.FreConCodAlimento)
                    .HasConstraintName("FK_Frecuencia_Consmo_Alimento");

                entity.HasOne(d => d.FreConNumeroAtencionNavigation)
                    .WithMany(p => p.FrecuenciaConsmo)
                    .HasForeignKey(d => d.FreConNumeroAtencion)
                    .HasConstraintName("FK_Frecuencia_Consmo_Atencion_Historia");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.GenCodigo);

                entity.Property(e => e.GenCodigo)
                    .HasColumnName("Gen_Codigo")
                    .HasMaxLength(1);

                entity.Property(e => e.GenDescripcion)
                    .IsRequired()
                    .HasColumnName("Gen_Descripcion")
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<HabitoDetalle>(entity =>
            {
                entity.HasKey(e => new { e.HabPacEntradaNumero, e.HabPacHabitoCodigo })
                    .HasName("PK_HabitoPaciente");

                entity.Property(e => e.HabPacEntradaNumero).HasColumnName("HabPac_Entrada_Numero");

                entity.Property(e => e.HabPacHabitoCodigo).HasColumnName("HabPac_Habito_Codigo");

                entity.Property(e => e.HabPacCaracteristica)
                    .HasColumnName("HabPac_Caracteristica")
                    .HasMaxLength(50);

                entity.Property(e => e.HabPacFrecuencia)
                    .HasColumnName("HabPac_Frecuencia")
                    .HasMaxLength(50);

                entity.Property(e => e.HabPacObservacion)
                    .HasColumnName("HabPac_Observacion")
                    .HasMaxLength(50);

                entity.Property(e => e.HabPacTiempo)
                    .HasColumnName("HabPac_Tiempo")
                    .HasMaxLength(50);

                entity.HasOne(d => d.HabPacEntradaNumeroNavigation)
                    .WithMany(p => p.HabitoDetalle)
                    .HasForeignKey(d => d.HabPacEntradaNumero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HabitoDetalle_Atencion_Historia");

                entity.HasOne(d => d.HabPacHabitoCodigoNavigation)
                    .WithMany(p => p.HabitoDetalle)
                    .HasForeignKey(d => d.HabPacHabitoCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HabitoDetalle_HABITOS");
            });

            modelBuilder.Entity<Habitos>(entity =>
            {
                entity.HasKey(e => e.HabCodigo);

                entity.ToTable("HABITOS");

                entity.HasIndex(e => e.HabCodigo)
                    .HasName("AK_HAB_CODIGO_PRIMARI_HABITOS")
                    .IsUnique();

                entity.Property(e => e.HabCodigo)
                    .HasColumnName("HAB_CODIGO")
                    .ValueGeneratedNever();

                entity.Property(e => e.HabDescripcion)
                    .HasColumnName("HAB_DESCRIPCION")
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HistorialPeso>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Historial_Peso");

                entity.Property(e => e.EntrNumero).HasColumnName("Entr_Numero");

                entity.Property(e => e.HistPesCodigo).HasColumnName("HistPes_Codigo");

                entity.Property(e => e.HistPesEdadSobrepeso)
                    .HasColumnName("HistPes_EdadSobrepeso")
                    .HasMaxLength(50);

                entity.Property(e => e.HistPesNumeroAtencion).HasColumnName("HistPes_NumeroAtencion");

                entity.Property(e => e.HistPesPesoMaximo)
                    .HasColumnName("HistPes_PesoMaximo")
                    .HasMaxLength(50);

                entity.Property(e => e.HistPesPesoMinimo)
                    .HasColumnName("HistPes_PesoMinimo")
                    .HasMaxLength(50);

                entity.Property(e => e.HistPesProblema)
                    .HasColumnName("HistPes_Problema")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<HistorialPeso1>(entity =>
            {
                entity.HasKey(e => e.HistPesCodigo);

                entity.ToTable("HistorialPeso");

                entity.Property(e => e.HistPesCodigo).HasColumnName("HistPes_Codigo");

                entity.Property(e => e.HistPesEdadSobrepeso)
                    .HasColumnName("HistPes_EdadSobrepeso")
                    .HasMaxLength(50);

                entity.Property(e => e.HistPesNumeroAtencion).HasColumnName("HistPes_NumeroAtencion");

                entity.Property(e => e.HistPesPesoMaximo)
                    .HasColumnName("HistPes_PesoMaximo")
                    .HasMaxLength(50);

                entity.Property(e => e.HistPesPesoMinimo)
                    .HasColumnName("HistPes_PesoMinimo")
                    .HasMaxLength(50);

                entity.Property(e => e.HistPesProblema)
                    .HasColumnName("HistPes_Problema")
                    .HasColumnType("text");

                entity.HasOne(d => d.HistPesNumeroAtencionNavigation)
                    .WithMany(p => p.HistorialPeso1)
                    .HasForeignKey(d => d.HistPesNumeroAtencion)
                    .HasConstraintName("FK_HistorialPeso_Atencion_Historia");
            });

            modelBuilder.Entity<Horarios>(entity =>
            {
                entity.ToTable("HORARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Fechaatencion)
                    .HasColumnName("FECHAATENCION")
                    .HasColumnType("date");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Finatencion).HasColumnName("FINATENCION");

                entity.Property(e => e.Inicioatencion).HasColumnName("INICIOATENCION");

                entity.Property(e => e.Medicoid).HasColumnName("MEDICOID");

                entity.HasOne(d => d.Medico)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.Medicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDICOS_HORARIOS");
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.MedicIdentificacion);

                entity.Property(e => e.MedicIdentificacion)
                    .HasColumnName("Medic_Identificacion")
                    .HasMaxLength(10);

                entity.Property(e => e.MedicApellido1)
                    .IsRequired()
                    .HasColumnName("Medic_Apellido1")
                    .HasMaxLength(20);

                entity.Property(e => e.MedicApellido2)
                    .HasColumnName("Medic_Apellido2")
                    .HasMaxLength(20);

                entity.Property(e => e.MedicFirma)
                    .HasColumnName("Medic_Firma")
                    .HasColumnType("image");

                entity.Property(e => e.MedicFoto)
                    .HasColumnName("Medic_Foto")
                    .HasColumnType("image");

                entity.Property(e => e.MedicHuella)
                    .HasColumnName("Medic_Huella")
                    .HasColumnType("image");

                entity.Property(e => e.MedicNombre1)
                    .IsRequired()
                    .HasColumnName("Medic_Nombre1")
                    .HasMaxLength(20);

                entity.Property(e => e.MedicNombre2)
                    .HasColumnName("Medic_Nombre2")
                    .HasMaxLength(20);

                entity.Property(e => e.MedicTipoIdentificacion)
                    .IsRequired()
                    .HasColumnName("Medic_TipoIdentificacion")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Medicos>(entity =>
            {
                entity.ToTable("MEDICOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("APELLIDOS")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("CORREO")
                    .HasMaxLength(50);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnName("FECHANACIMIENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("NOMBRES")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Numcolegiatura)
                    .IsRequired()
                    .HasColumnName("NUMCOLEGIATURA")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("SEXO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MedicosEspecialidades>(entity =>
            {
                entity.ToTable("MEDICOS_ESPECIALIDADES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Especialidadid).HasColumnName("ESPECIALIDADID");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Medicoid).HasColumnName("MEDICOID");

                entity.HasOne(d => d.Especialidad)
                    .WithMany(p => p.MedicosEspecialidades)
                    .HasForeignKey(d => d.Especialidadid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESPECIALIDADES");

                entity.HasOne(d => d.Medico)
                    .WithMany(p => p.MedicosEspecialidades)
                    .HasForeignKey(d => d.Medicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MEDICOS");
            });

            modelBuilder.Entity<NivelEducativo>(entity =>
            {
                entity.HasKey(e => e.NivEduCodigo);

                entity.Property(e => e.NivEduCodigo).HasColumnName("NivEdu_Codigo");

                entity.Property(e => e.NivEduDescripcion)
                    .HasColumnName("NivEdu_Descripcion")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Ocupacion>(entity =>
            {
                entity.HasKey(e => e.OcupCodigo);

                entity.Property(e => e.OcupCodigo).HasColumnName("Ocup_Codigo");

                entity.Property(e => e.OcupDescripcion)
                    .HasColumnName("Ocup_Descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.PacIdentificacion);

                entity.Property(e => e.PacIdentificacion)
                    .HasColumnName("Pac_Identificacion")
                    .HasMaxLength(10);

                entity.Property(e => e.PacApellido1)
                    .IsRequired()
                    .HasColumnName("Pac_Apellido1")
                    .HasMaxLength(20);

                entity.Property(e => e.PacApellido2)
                    .HasColumnName("Pac_Apellido2")
                    .HasMaxLength(20);

                entity.Property(e => e.PacCodArl).HasColumnName("Pac_CodARL");

                entity.Property(e => e.PacCodCiudad)
                    .IsRequired()
                    .HasColumnName("Pac_CodCiudad")
                    .HasMaxLength(3);

                entity.Property(e => e.PacCodDepto)
                    .IsRequired()
                    .HasColumnName("Pac_CodDepto")
                    .HasMaxLength(2);

                entity.Property(e => e.PacCodEps).HasColumnName("Pac_CodEPS");

                entity.Property(e => e.PacCodGenero)
                    .IsRequired()
                    .HasColumnName("Pac_CodGenero")
                    .HasMaxLength(1);

                entity.Property(e => e.PacCodNivelEducativo).HasColumnName("Pac_CodNivelEducativo");

                entity.Property(e => e.PacCodProfesion)
                    .IsRequired()
                    .HasColumnName("Pac_CodProfesion")
                    .HasMaxLength(4);

                entity.Property(e => e.PacDireccion)
                    .HasColumnName("Pac_Direccion")
                    .HasMaxLength(50);

                entity.Property(e => e.PacDominanciaCodigo).HasColumnName("Pac_Dominancia_Codigo");

                entity.Property(e => e.PacEstadoCivil).HasColumnName("Pac_EstadoCivil");

                entity.Property(e => e.PacFecha)
                    .HasColumnName("Pac_Fecha")
                    .HasColumnType("date");

                entity.Property(e => e.PacFechaNacimiento)
                    .HasColumnName("Pac_FechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.PacFirma)
                    .HasColumnName("Pac_Firma")
                    .HasColumnType("image");

                entity.Property(e => e.PacFoto)
                    .HasColumnName("Pac_Foto")
                    .HasColumnType("image");

                entity.Property(e => e.PacHuella)
                    .HasColumnName("Pac_Huella")
                    .HasColumnType("image");

                entity.Property(e => e.PacNombre1)
                    .IsRequired()
                    .HasColumnName("Pac_Nombre1")
                    .HasMaxLength(20);

                entity.Property(e => e.PacNombre2)
                    .HasColumnName("Pac_Nombre2")
                    .HasMaxLength(20);

                entity.Property(e => e.PacTelefono)
                    .HasColumnName("Pac_Telefono")
                    .HasMaxLength(12);

                entity.Property(e => e.PacTipoIdentificacion)
                    .IsRequired()
                    .HasColumnName("Pac_TipoIdentificacion")
                    .HasMaxLength(3);

                entity.Property(e => e.PacTipoSangre).HasColumnName("Pac_TipoSangre");

                entity.HasOne(d => d.PacCodArlNavigation)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.PacCodArl)
                    .HasConstraintName("FK_Paciente_ARL");

                entity.HasOne(d => d.PacCodEpsNavigation)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.PacCodEps)
                    .HasConstraintName("FK_Paciente_EPS");

                entity.HasOne(d => d.PacDominanciaCodigoNavigation)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.PacDominanciaCodigo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paciente_Dominancia");

                entity.HasOne(d => d.PacTipoIdentificacionNavigation)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.PacTipoIdentificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paciente_TipoDocumento");

                entity.HasOne(d => d.PacTipoSangreNavigation)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.PacTipoSangre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paciente_TipoSangre");

                entity.HasOne(d => d.PacCod)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => new { d.PacCodDepto, d.PacCodCiudad })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Paciente_Ciudad");
            });

            modelBuilder.Entity<Pacientes>(entity =>
            {
                entity.ToTable("PACIENTES");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasColumnName("APELLIDOS")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("DIRECCION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fechanacimiento)
                    .HasColumnName("FECHANACIMIENTO")
                    .HasColumnType("date");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnName("FECHAREGISTRO")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Identificacion)
                    .IsRequired()
                    .HasColumnName("IDENTIFICACION")
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasColumnName("NOMBRES")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("SEXO")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("TELEFONO")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesion>(entity =>
            {
                entity.HasKey(e => e.ProfCodigo);

                entity.Property(e => e.ProfCodigo)
                    .HasColumnName("Prof_Codigo")
                    .HasMaxLength(4);

                entity.Property(e => e.ProfDescripcion)
                    .IsRequired()
                    .HasColumnName("Prof_Descripcion")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Recordatorio>(entity =>
            {
                entity.HasKey(e => e.RecordCodigo);

                entity.Property(e => e.RecordCodigo).HasColumnName("Record_Codigo");

                entity.Property(e => e.RecordCantidad).HasColumnName("Record_Cantidad");

                entity.Property(e => e.RecordCodComida).HasColumnName("Record_CodComida");

                entity.Property(e => e.RecordHora)
                    .HasColumnName("Record_Hora")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordNumeroAtencion).HasColumnName("Record_NumeroAtencion");

                entity.Property(e => e.RecordPreparacion)
                    .HasColumnName("Record_Preparacion")
                    .HasColumnType("text");

                entity.HasOne(d => d.RecordCodComidaNavigation)
                    .WithMany(p => p.Recordatorio)
                    .HasForeignKey(d => d.RecordCodComida)
                    .HasConstraintName("FK_Recordatorio_Comida");

                entity.HasOne(d => d.RecordNumeroAtencionNavigation)
                    .WithMany(p => p.Recordatorio)
                    .HasForeignKey(d => d.RecordNumeroAtencion)
                    .HasConstraintName("FK_Recordatorio_Atencion_Historia");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.TipoIdeCodigo)
                    .HasName("PK_Tipo_Identificacion");

                entity.Property(e => e.TipoIdeCodigo)
                    .HasColumnName("TipoIde_Codigo")
                    .HasMaxLength(3);

                entity.Property(e => e.TipoIdeDescripcion)
                    .IsRequired()
                    .HasColumnName("TipoIde_Descripcion")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<TipoSangre>(entity =>
            {
                entity.HasKey(e => e.TipSanCodigo);

                entity.Property(e => e.TipSanCodigo).HasColumnName("TipSan_Codigo");

                entity.Property(e => e.TipSanDescripcion)
                    .IsRequired()
                    .HasColumnName("TipSan_Descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuNombre)
                    .HasName("PK_Usuario_1");

                entity.Property(e => e.UsuNombre)
                    .HasColumnName("Usu_Nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.UsuContraseña)
                    .IsRequired()
                    .HasColumnName("Usu_Contraseña")
                    .HasMaxLength(20);

                entity.Property(e => e.UsuEstado)
                    .HasColumnName("Usu_Estado")
                    .HasMaxLength(1);

                entity.Property(e => e.UsuFechaCaduca)
                    .HasColumnName("Usu_FechaCaduca")
                    .HasColumnType("date");

                entity.Property(e => e.UsuNombreCompleto)
                    .IsRequired()
                    .HasColumnName("Usu_NombreCompleto")
                    .HasMaxLength(100);

                entity.Property(e => e.UsuTipo)
                    .HasColumnName("Usu_Tipo")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<UsuarioModulo>(entity =>
            {
                entity.HasKey(e => new { e.UsuModUsuario, e.UsuModModulo });

                entity.Property(e => e.UsuModUsuario)
                    .HasColumnName("UsuMod_Usuario")
                    .HasMaxLength(50);

                entity.Property(e => e.UsuModModulo).HasColumnName("UsuMod_Modulo");

                entity.HasOne(d => d.UsuModUsuarioNavigation)
                    .WithMany(p => p.UsuarioModulo)
                    .HasForeignKey(d => d.UsuModUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioModulo_Usuario");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("ACTIVO")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("CLAVE")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Medicoid).HasColumnName("MEDICOID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewPaciente>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Paciente");

                entity.Property(e => e.ArlCodigo).HasColumnName("Arl_Codigo");

                entity.Property(e => e.ArlDescripcion)
                    .IsRequired()
                    .HasColumnName("Arl_Descripcion")
                    .HasMaxLength(300);

                entity.Property(e => e.CiudCodDepto)
                    .IsRequired()
                    .HasColumnName("Ciud_CodDepto")
                    .HasMaxLength(2);

                entity.Property(e => e.CiudCodigo)
                    .IsRequired()
                    .HasColumnName("Ciud_Codigo")
                    .HasMaxLength(3);

                entity.Property(e => e.CiudNombre)
                    .IsRequired()
                    .HasColumnName("Ciud_Nombre")
                    .HasMaxLength(25);

                entity.Property(e => e.DeptCodigo)
                    .IsRequired()
                    .HasColumnName("Dept_Codigo")
                    .HasMaxLength(2);

                entity.Property(e => e.DeptNombre)
                    .IsRequired()
                    .HasColumnName("Dept_Nombre")
                    .HasMaxLength(25);

                entity.Property(e => e.EpsCodigo).HasColumnName("Eps_Codigo");

                entity.Property(e => e.EpsDescripcion)
                    .IsRequired()
                    .HasColumnName("Eps_Descripcion")
                    .HasMaxLength(300);

                entity.Property(e => e.PacApellido1)
                    .IsRequired()
                    .HasColumnName("Pac_Apellido1")
                    .HasMaxLength(20);

                entity.Property(e => e.PacApellido2)
                    .HasColumnName("Pac_Apellido2")
                    .HasMaxLength(20);

                entity.Property(e => e.PacCodArl).HasColumnName("Pac_CodARL");

                entity.Property(e => e.PacCodCiudad)
                    .IsRequired()
                    .HasColumnName("Pac_CodCiudad")
                    .HasMaxLength(3);

                entity.Property(e => e.PacCodDepto)
                    .IsRequired()
                    .HasColumnName("Pac_CodDepto")
                    .HasMaxLength(2);

                entity.Property(e => e.PacCodEps).HasColumnName("Pac_CodEPS");

                entity.Property(e => e.PacCodGenero)
                    .IsRequired()
                    .HasColumnName("Pac_CodGenero")
                    .HasMaxLength(1);

                entity.Property(e => e.PacCodNivelEducativo).HasColumnName("Pac_CodNivelEducativo");

                entity.Property(e => e.PacCodProfesion)
                    .IsRequired()
                    .HasColumnName("Pac_CodProfesion")
                    .HasMaxLength(4);

                entity.Property(e => e.PacDireccion)
                    .HasColumnName("Pac_Direccion")
                    .HasMaxLength(50);

                entity.Property(e => e.PacDominanciaCodigo).HasColumnName("Pac_Dominancia_Codigo");

                entity.Property(e => e.PacEstadoCivil).HasColumnName("Pac_EstadoCivil");

                entity.Property(e => e.PacFecha)
                    .HasColumnName("Pac_Fecha")
                    .HasColumnType("date");

                entity.Property(e => e.PacFechaNacimiento)
                    .HasColumnName("Pac_FechaNacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.PacFirma)
                    .HasColumnName("Pac_Firma")
                    .HasColumnType("image");

                entity.Property(e => e.PacFoto)
                    .HasColumnName("Pac_Foto")
                    .HasColumnType("image");

                entity.Property(e => e.PacHuella)
                    .HasColumnName("Pac_Huella")
                    .HasColumnType("image");

                entity.Property(e => e.PacIdentificacion)
                    .IsRequired()
                    .HasColumnName("Pac_Identificacion")
                    .HasMaxLength(10);

                entity.Property(e => e.PacNombre1)
                    .IsRequired()
                    .HasColumnName("Pac_Nombre1")
                    .HasMaxLength(20);

                entity.Property(e => e.PacNombre2)
                    .HasColumnName("Pac_Nombre2")
                    .HasMaxLength(20);

                entity.Property(e => e.PacTelefono)
                    .HasColumnName("Pac_Telefono")
                    .HasMaxLength(12);

                entity.Property(e => e.PacTipoIdentificacion)
                    .IsRequired()
                    .HasColumnName("Pac_TipoIdentificacion")
                    .HasMaxLength(3);

                entity.Property(e => e.PacTipoSangre).HasColumnName("Pac_TipoSangre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
