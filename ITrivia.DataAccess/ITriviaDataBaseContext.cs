using System;
using System.Collections.Generic;
using ITrivia.Types.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ITrivia.DataAccess
{
    public partial class ITriviaDataBaseContext : DbContext
    {
        public ITriviaDataBaseContext()
        {
        }

        public ITriviaDataBaseContext(DbContextOptions<ITriviaDataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GesPtipoJuego> GesPtipoJuegos { get; set; } = null!;
        public virtual DbSet<GesTautocompletado> GesTautocompletados { get; set; } = null!;
        public virtual DbSet<GesTcategoria> GesTcategorias { get; set; } = null!;
        public virtual DbSet<GesTdesafio> GesTdesafios { get; set; } = null!;
        public virtual DbSet<GesTetapa> GesTetapas { get; set; } = null!;
        public virtual DbSet<GesThistPerfilDesafio> GesThistPerfilDesafios { get; set; } = null!;
        public virtual DbSet<GesThistPerfilSeccione> GesThistPerfilSecciones { get; set; } = null!;
        public virtual DbSet<GesTmultiplechoice> GesTmultiplechoices { get; set; } = null!;
        public virtual DbSet<GesTperfile> GesTperfiles { get; set; } = null!;
        public virtual DbSet<GesTseccione> GesTsecciones { get; set; } = null!;
        public virtual DbSet<GesTselecPare> GesTselecPares { get; set; } = null!;
        public virtual DbSet<ParPetiqueta> ParPetiquetas { get; set; } = null!;
        public virtual DbSet<ParPimagene> ParPimagenes { get; set; } = null!;
        public virtual DbSet<ParPmensaje> ParPmensajes { get; set; } = null!;
        public virtual DbSet<SegProle> SegProles { get; set; } = null!;
        public virtual DbSet<SegTusuario> SegTusuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=127.0.0.1,1433;user id=SA;password=Super_P@ssword1;initial catalog=ITrivia.Database;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GesPtipoJuego>(entity =>
            {
                entity.ToTable("ges_ptipo_juego", "gestion");

                entity.HasIndex(e => e.Codigo, "IQ_ptipjuego_cod")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<GesTautocompletado>(entity =>
            {
                entity.ToTable("ges_tautocompletado", "gestion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.Enunciado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("enunciado");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Respuesta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("respuesta");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<GesTcategoria>(entity =>
            {
                entity.ToTable("ges_tcategorias", "gestion");

                entity.HasIndex(e => e.Nombre, "IQ_tcat_nom")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<GesTdesafio>(entity =>
            {
                entity.ToTable("ges_tdesafios", "gestion");

                entity.HasIndex(e => e.Nombre, "IQ_tdes_nom")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activated).HasColumnName("activated");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.CantEtapas).HasColumnName("cant_etapas");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Experiencia).HasColumnName("experiencia");

                entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdSeccionNavigation)
                    .WithMany(p => p.GesTdesafios)
                    .HasForeignKey(d => d.IdSeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tdesafios_tsecciones");
            });

            modelBuilder.Entity<GesTetapa>(entity =>
            {
                entity.ToTable("ges_tetapas", "gestion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.IdAutocompletado).HasColumnName("id_autocompletado");

                entity.Property(e => e.IdDesafio).HasColumnName("id_desafio");

                entity.Property(e => e.IdMchoice).HasColumnName("id_mchoice");

                entity.Property(e => e.IdSpares).HasColumnName("id_spares");

                entity.Property(e => e.IdTipoJuego).HasColumnName("id_tipo_juego");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdAutocompletadoNavigation)
                    .WithMany(p => p.GesTetapas)
                    .HasForeignKey(d => d.IdAutocompletado)
                    .HasConstraintName("FK_tetapa_tautocomp");

                entity.HasOne(d => d.IdDesafioNavigation)
                    .WithMany(p => p.GesTetapas)
                    .HasForeignKey(d => d.IdDesafio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ttetapas_tdesafios");

                entity.HasOne(d => d.IdMchoiceNavigation)
                    .WithMany(p => p.GesTetapas)
                    .HasForeignKey(d => d.IdMchoice)
                    .HasConstraintName("FK_tetapa_tmultchoice");

                entity.HasOne(d => d.IdSparesNavigation)
                    .WithMany(p => p.GesTetapas)
                    .HasForeignKey(d => d.IdSpares)
                    .HasConstraintName("FK_tetapa_tspares");

                entity.HasOne(d => d.IdTipoJuegoNavigation)
                    .WithMany(p => p.GesTetapas)
                    .HasForeignKey(d => d.IdTipoJuego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ttiposjuegos_tdesafios");
            });

            modelBuilder.Entity<GesThistPerfilDesafio>(entity =>
            {
                entity.ToTable("ges_thist_perfil_desafios", "gestion");

                entity.HasIndex(e => new { e.IdPerfil, e.IdDesafio }, "IQ_thistps_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.IdDesafio).HasColumnName("id_desafio");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdDesafioNavigation)
                    .WithMany(p => p.GesThistPerfilDesafios)
                    .HasForeignKey(d => d.IdDesafio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_hist_perfil_desafio_desafios");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.GesThistPerfilDesafios)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_hist_perfil");
            });

            modelBuilder.Entity<GesThistPerfilSeccione>(entity =>
            {
                entity.ToTable("ges_thist_perfil_secciones", "gestion");

                entity.HasIndex(e => new { e.IdPerfil, e.IdSeccion }, "IQ_thistps_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.IdSeccion).HasColumnName("id_seccion");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdSeccionNavigation)
                    .WithMany(p => p.GesThistPerfilSecciones)
                    .HasForeignKey(d => d.IdSeccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_hist_perfil_desafio_tsecciones");
            });

            modelBuilder.Entity<GesTmultiplechoice>(entity =>
            {
                entity.ToTable("ges_tmultiplechoice", "gestion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.Enunciado)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("enunciado");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Opcion1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("opcion1");

                entity.Property(e => e.Opcion2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("opcion2");

                entity.Property(e => e.OpcionCorrecta)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("opcion_correcta");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<GesTperfile>(entity =>
            {
                entity.ToTable("ges_tperfiles", "gestion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.Exp).HasColumnName("exp");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<GesTseccione>(entity =>
            {
                entity.ToTable("ges_tsecciones", "gestion");

                entity.HasIndex(e => e.Nombre, "IQ_tsec_nom")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activated).HasColumnName("activated");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.CantDesafios).HasColumnName("cant_desafios");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.UrlImagen)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("url_imagen");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.GesTsecciones)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tsecciones_tcategorias");
            });

            modelBuilder.Entity<GesTselecPare>(entity =>
            {
                entity.ToTable("ges_tselec_pares", "gestion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Opcion1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("opcion1");

                entity.Property(e => e.Opcion2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("opcion2");

                entity.Property(e => e.Opcion3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("opcion3");

                entity.Property(e => e.Opcion4)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("opcion4");

                entity.Property(e => e.Respuesta1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("respuesta1");

                entity.Property(e => e.Respuesta2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("respuesta2");

                entity.Property(e => e.Respuesta3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("respuesta3");

                entity.Property(e => e.Respuesta4)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("respuesta4");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<ParPetiqueta>(entity =>
            {
                entity.ToTable("par_petiquetas", "parametros");

                entity.HasIndex(e => e.Codigo, "IQ_plbl_codigo")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Espanol)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("espanol");

                entity.Property(e => e.Ingles)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ingles");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<ParPimagene>(entity =>
            {
                entity.ToTable("par_pimagenes", "parametros");

                entity.HasIndex(e => e.Codigo, "IQ_pimg_cod")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.UrlImagen)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("url_imagen");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<ParPmensaje>(entity =>
            {
                entity.ToTable("par_pmensajes", "parametros");

                entity.HasIndex(e => e.Codigo, "IQ_pmge_code")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.Espanol)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("espanol");

                entity.Property(e => e.Ingles)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ingles");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<SegProle>(entity =>
            {
                entity.ToTable("seg_proles", "seguridad");

                entity.HasIndex(e => e.Codigo, "IQ_trol_cod")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("codigo");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");
            });

            modelBuilder.Entity<SegTusuario>(entity =>
            {
                entity.ToTable("seg_tusuarios", "seguridad");

                entity.HasIndex(e => e.IdPerfil, "IQ_tuser_idperfil")
                    .IsUnique()
                    .HasFilter("([id_perfil] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AltaFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("alta_fecha");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Baja).HasColumnName("baja");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdImagen).HasColumnName("id_imagen");

                entity.Property(e => e.IdPerfil).HasColumnName("id_perfil");

                entity.Property(e => e.IdRol).HasColumnName("id_rol");

                entity.Property(e => e.ModiFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("modi_fecha");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuario");

                entity.HasOne(d => d.IdImagenNavigation)
                    .WithMany(p => p.SegTusuarios)
                    .HasForeignKey(d => d.IdImagen)
                    .HasConstraintName("FK_tusuarios_pimagenes");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithOne(p => p.SegTusuario)
                    .HasForeignKey<SegTusuario>(d => d.IdPerfil)
                    .HasConstraintName("FK_tusuarios_tperfiles");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.SegTusuarios)
                    .HasForeignKey(d => d.IdRol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tusuarios_troles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
