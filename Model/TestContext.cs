using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model
{
    public partial class TestContext : DbContext
    {
        public TestContext()
            : base("name=TestContext")
        {
        }

        public virtual DbSet<Adjunto> Adjunto { get; set; }
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<AlumnoCurso> AlumnoCurso { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Adjunto>()
            //    .Property(e => e.Archivo)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Alumno>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Alumno>()
            //    .Property(e => e.Apellido)
            //    .IsUnicode(false);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Adjunto)
                .WithRequired(e => e.Alumno)
                .HasForeignKey(e => e.Alumno_id);
            //.WillCascadeOnDelete(false);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.AlumnoCurso)
                .WithRequired(e => e.Alumno)
                .HasForeignKey(e => e.Alumno_id);
            //.WillCascadeOnDelete(false);

            //modelBuilder.Entity<Curso>()
            //    .Property(e => e.Nombre)
            //    .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.AlumnoCurso)
                .WithRequired(e => e.Curso)
                .HasForeignKey(e => e.Curso_id);
                //.WillCascadeOnDelete(false);
        }
    }
}
