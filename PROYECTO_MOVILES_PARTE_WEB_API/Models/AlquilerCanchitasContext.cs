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
    public virtual DbSet<Asistencia> Asistencias { get; set; }
    public virtual DbSet<Cancha> Canchas { get; set; }
    public virtual DbSet<Clase> Clases { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<PrestamoBalon> PrestamoBalons { get; set; }
    public virtual DbSet<Reserva> Reservas { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);
            entity.ToTable("USUARIO");
            entity.HasIndex(e => e.UsernameUsuario, "uq_usuario_username").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.UsernameUsuario).HasMaxLength(50).IsUnicode(false).HasColumnName("username_usuario");
            entity.Property(e => e.NombreUsuario).HasMaxLength(100).IsUnicode(false).HasColumnName("nombre_usuario");
            entity.Property(e => e.Telefono).HasMaxLength(20).IsUnicode(false).HasColumnName("telefono");
            entity.Property(e => e.Password).HasMaxLength(255).IsUnicode(false).HasColumnName("password");
            entity.Property(e => e.ActivoUsuario).HasDefaultValue(true).HasColumnName("activo_usuario");
            entity.Property(e => e.Rol).HasMaxLength(20).IsUnicode(false).HasColumnName("rol");
        });

        modelBuilder.Entity<Cancha>(entity =>
        {
            entity.HasKey(e => e.IdCancha);
            entity.ToTable("CANCHA");

            entity.Property(e => e.IdCancha).HasColumnName("id_cancha");
            entity.Property(e => e.NombreCancha).HasMaxLength(50).IsUnicode(false).HasColumnName("nombre_cancha");
            entity.Property(e => e.DescripcionCancha).HasMaxLength(150).IsUnicode(false).HasColumnName("descripcion_cancha");
            entity.Property(e => e.PrecioAlquiler).HasColumnType("decimal(10, 2)").HasColumnName("precio_alquiler");
            entity.Property(e => e.ActivoCancha).HasDefaultValue(true).HasColumnName("activo_cancha");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);
            entity.ToTable("CLIENTE");
            entity.HasIndex(e => e.NumeroDocumento, "uq_cliente_dni").IsUnique();

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.NombreCliente).HasMaxLength(100).IsUnicode(false).HasColumnName("nombre_cliente");
            entity.Property(e => e.TipoCliente).HasMaxLength(20).IsUnicode(false).HasColumnName("tipo_cliente");
            entity.Property(e => e.ActivoCliente).HasDefaultValue(true).HasColumnName("activo_cliente");
            entity.Property(e => e.NumeroDocumento).HasMaxLength(20).IsUnicode(false).HasColumnName("numero_documento");
            entity.Property(e => e.TelefonoCliente).HasMaxLength(20).IsUnicode(false).HasColumnName("telefono_cliente");
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.IdReserva);
            entity.ToTable("RESERVA", tb =>
            {
                tb.HasTrigger("trg_reserva_sin_cruces");
                tb.HasTrigger("trg_reserva_rol_usuario");
            });

            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.HoraInicio).HasColumnName("hora_inicio");
            entity.Property(e => e.HoraFin).HasColumnName("hora_fin");
            entity.Property(e => e.PrecioReserva).HasColumnType("decimal(10, 2)").HasColumnName("precio_reserva");
            entity.Property(e => e.EstadoReserva).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Pendiente").HasColumnName("estado_reserva");
            entity.Property(e => e.MontoRecibido).HasColumnType("decimal(10, 2)").HasDefaultValue(0m).HasColumnName("monto_recibido");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdCancha).HasColumnName("id_cancha");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserva_cliente");

            entity.HasOne(d => d.IdCanchaNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdCancha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserva_cancha");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserva_usuario");
        });

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno);
            entity.ToTable("ALUMNO", tb => tb.HasTrigger("trg_alumno_rol_usuario"));

            entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");
            entity.Property(e => e.NombreAlumno).HasMaxLength(100).IsUnicode(false).HasColumnName("nombre_alumno");
            entity.Property(e => e.TelefonoApoderado).HasMaxLength(20).IsUnicode(false).HasColumnName("telefono_apoderado");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.ActivoAlumno).HasDefaultValue(true).HasColumnName("activo_alumno");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_alumno_usuario");
        });

        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.IdClase);
            entity.ToTable("CLASE", tb =>
            {
                tb.HasTrigger("trg_clase_sin_cruces");
                tb.HasTrigger("trg_clase_rol_usuario");
                tb.HasTrigger("trg_clase_cierre");
            });

            entity.Property(e => e.IdClase).HasColumnName("id_clase");
            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.IdCancha).HasColumnName("id_cancha");
            entity.Property(e => e.FechaClase).HasColumnName("fecha_clase");
            entity.Property(e => e.HoraInicio).HasPrecision(0).HasColumnName("hora_inicio");
            entity.Property(e => e.HoraFin).HasPrecision(0).HasColumnName("hora_fin");
            entity.Property(e => e.EstadoClase).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Programada").HasColumnName("estado_clase");
            entity.Property(e => e.ActivoClase).HasDefaultValue(true).HasColumnName("activo_clase");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clases)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("fk_clase_usuario");

            entity.HasOne(d => d.IdCanchaNavigation).WithMany(p => p.Clases)
                .HasForeignKey(d => d.IdCancha)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clase_cancha");
        });

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia);
            entity.ToTable("ASISTENCIA", tb =>
            {
                tb.HasTrigger("trg_asistencia_validar");
                tb.HasTrigger("trg_asistencia_no_borrar_cerrada");
            });

            entity.HasIndex(e => new { e.IdClase, e.IdAlumno }, "uq_asistencia_clase_alumno").IsUnique();

            entity.Property(e => e.IdAsistencia).HasColumnName("id_asistencia");
            entity.Property(e => e.IdClase).HasColumnName("id_clase");
            entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");
            entity.Property(e => e.EstadoAsistencia).HasMaxLength(20).IsUnicode(false).HasColumnName("estado_asistencia");

            entity.HasOne(d => d.IdClaseNavigation).WithMany(p => p.Asistencias)
                .HasForeignKey(d => d.IdClase)
                .HasConstraintName("fk_asistencia_clase");

            entity.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.Asistencias)
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("fk_asistencia_alumno");
        });

        modelBuilder.Entity<PrestamoBalon>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo);
            entity.ToTable("PRESTAMO_BALON", tb => tb.HasTrigger("trg_prestamo_validar"));

            entity.Property(e => e.IdPrestamo).HasColumnName("id_prestamo");
            entity.Property(e => e.IdReserva).HasColumnName("id_reserva");
            entity.Property(e => e.IdClase).HasColumnName("id_clase");
            entity.Property(e => e.FechaEntrega).HasColumnName("fecha_entrega");
            entity.Property(e => e.FechaDevolucion).HasColumnName("fecha_devolucion");
            entity.Property(e => e.EstadoPrestamo).HasMaxLength(20).IsUnicode(false).HasDefaultValue("Pendiente").HasColumnName("estado_prestamo");

            entity.HasOne(d => d.IdReservaNavigation).WithMany(p => p.PrestamoBalons)
                .HasForeignKey(d => d.IdReserva)
                .HasConstraintName("fk_prestamo_reserva");

            entity.HasOne(d => d.IdClaseNavigation).WithMany(p => p.PrestamoBalons)
                .HasForeignKey(d => d.IdClase)
                .HasConstraintName("fk_prestamo_clase");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
