using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PROYECTO_MOVILES_PARTE_WEB_API.Models;

public partial class AlquilerCanchitasContext : DbContext
{
    public AlquilerCanchitasContext()
    {
    }

    public AlquilerCanchitasContext(DbContextOptions<AlquilerCanchitasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Asistencia> Asistencia { get; set; }

    public virtual DbSet<Cancha> Canchas { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<HorarioAcademia> HorarioAcademia { get; set; }

    public virtual DbSet<PrestamoBalon> PrestamoBalons { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.PkIdAlumno).HasName("PK__ALUMNO__90593D279D0045BA");

            entity.ToTable("ALUMNO");

            entity.Property(e => e.PkIdAlumno).HasColumnName("PK_id_alumno");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.FkIdProfesor).HasColumnName("FK_id_profesor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TelefonoApoderado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono_apoderado");

            entity.HasOne(d => d.FkIdProfesorNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.FkIdProfesor)
                .HasConstraintName("fk_alumno_profesor");
        });

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.PkIdAsistencia).HasName("PK__ASISTENC__0507D6EE0374FB5C");

            entity.ToTable("ASISTENCIA");

            entity.Property(e => e.PkIdAsistencia).HasColumnName("PK_id_asistencia");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaClase).HasColumnName("fecha_clase");
            entity.Property(e => e.FkIdAlumno).HasColumnName("FK_id_alumno");

            entity.HasOne(d => d.FkIdAlumnoNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.FkIdAlumno)
                .HasConstraintName("fk_asistencia_alumno");
        });

        modelBuilder.Entity<Cancha>(entity =>
        {
            entity.HasKey(e => e.PkIdCancha).HasName("PK__CANCHA__8D4B63BA03025D23");

            entity.ToTable("CANCHA");

            entity.Property(e => e.PkIdCancha).HasColumnName("PK_id_cancha");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioAlquiler)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_alquiler");
            entity.Property(e => e.TipoDeporteCesped)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_deporte_cesped");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.PkIdCliente).HasName("PK__CLIENTE__A3A81B3F694ED9F6");

            entity.ToTable("CLIENTE");

            entity.HasIndex(e => e.Dni, "uq_cliente_dni").IsUnique();

            entity.Property(e => e.PkIdCliente).HasColumnName("PK_id_cliente");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Dni)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tipo_cliente");
        });

        modelBuilder.Entity<HorarioAcademia>(entity =>
        {
            entity.HasKey(e => e.PkIdHorario).HasName("PK__HORARIO___986B40ECC34E3638");

            entity.ToTable("HORARIO_ACADEMIA", tb => tb.HasTrigger("trg_horario_academia_no_overlap"));

            entity.Property(e => e.PkIdHorario).HasColumnName("PK_id_horario");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.DiaSemana)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dia_semana");
            entity.Property(e => e.FkIdCancha).HasColumnName("FK_id_cancha");
            entity.Property(e => e.FkIdProfesor).HasColumnName("FK_id_profesor");
            entity.Property(e => e.HoraFin)
                .HasPrecision(0)
                .HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio)
                .HasPrecision(0)
                .HasColumnName("hora_inicio");

            entity.HasOne(d => d.FkIdCanchaNavigation).WithMany(p => p.HorarioAcademia)
                .HasForeignKey(d => d.FkIdCancha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_horario_cancha");

            entity.HasOne(d => d.FkIdProfesorNavigation).WithMany(p => p.HorarioAcademia)
                .HasForeignKey(d => d.FkIdProfesor)
                .HasConstraintName("fk_horario_profesor");
        });

        modelBuilder.Entity<PrestamoBalon>(entity =>
        {
            entity.HasKey(e => e.PkIdPrestamo).HasName("PK__PRESTAMO__B13DC6965DA3C6D3");

            entity.ToTable("PRESTAMO_BALON");

            entity.Property(e => e.PkIdPrestamo).HasColumnName("PK_id_prestamo");
            entity.Property(e => e.DniGarantia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("dni_garantia");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FechaDevolucion).HasColumnName("fecha_devolucion");
            entity.Property(e => e.FechaEntrega).HasColumnName("fecha_entrega");
            entity.Property(e => e.FkIdReserva).HasColumnName("FK_id_reserva");

            entity.HasOne(d => d.FkIdReservaNavigation).WithMany(p => p.PrestamoBalons)
                .HasForeignKey(d => d.FkIdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_prestamo_reserva");
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.PkIdProfesor).HasName("PK__PROFESOR__B58982DC5B7A6744");

            entity.ToTable("PROFESOR");

            entity.HasIndex(e => e.FkIdUsuario, "UQ__PROFESOR__42628239B7AC3DC5").IsUnique();

            entity.Property(e => e.PkIdProfesor).HasColumnName("PK_id_profesor");
            entity.Property(e => e.CategoriaEdad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria_edad");
            entity.Property(e => e.FkIdUsuario).HasColumnName("FK_id_usuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithOne(p => p.Profesor)
                .HasForeignKey<Profesor>(d => d.FkIdUsuario)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_profesor_usuario");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.PkIdReserva).HasName("PK__RESERVA__01CA262A10537BE9");

            entity.ToTable("RESERVA", tb => tb.HasTrigger("trg_reserva_no_overlap"));

            entity.Property(e => e.PkIdReserva).HasColumnName("PK_id_reserva");
            entity.Property(e => e.Adelanto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("adelanto");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente")
                .HasColumnName("estado");
            entity.Property(e => e.FkIdCancha).HasColumnName("FK_id_cancha");
            entity.Property(e => e.FkIdCliente).HasColumnName("FK_id_cliente");
            entity.Property(e => e.FkIdUsuario).HasColumnName("FK_id_usuario");
            entity.Property(e => e.HoraFin).HasColumnName("hora_fin");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            entity.Property(e => e.Saldo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("saldo");

            entity.HasOne(d => d.FkIdCanchaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.FkIdCancha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserva_cancha");

            entity.HasOne(d => d.FkIdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.FkIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserva_cliente");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.FkIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserva_usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.PkIdUsuario).HasName("PK__USUARIO__25C4350567F1C697");

            entity.ToTable("USUARIO");

            entity.HasIndex(e => e.Username, "uq_usuario_username").IsUnique();

            entity.Property(e => e.PkIdUsuario).HasColumnName("PK_id_usuario");
            entity.Property(e => e.Activo)
                .HasDefaultValue(true)
                .HasColumnName("activo");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Rol)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
