using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiGetechnologiesMx.Models
{
    public partial class GetechnologiesMxContext : DbContext
    {
        public GetechnologiesMxContext()
        {
        }

        public GetechnologiesMxContext(DbContextOptions<GetechnologiesMxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=DESKTOP-GHR0T5I\\SQLEXPRESS; database=GetechnologiesMx; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Factura");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("monto");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Facturas_Persona");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Persona");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .HasColumnName("apellidoMaterno")
                    .IsFixedLength();

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .HasColumnName("apellidoPaterno")
                    .IsFixedLength();

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .HasColumnName("identificacion")
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
