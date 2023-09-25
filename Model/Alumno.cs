namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Alumno")]
    public partial class Alumno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumno()
        {
            Adjunto = new HashSet<Adjunto>();
            AlumnoCurso = new HashSet<AlumnoCurso>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        public int Sexo { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adjunto> Adjunto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }

        public List<Alumno> Listar() 
        {
            var alumnos = new List<Alumno>();
            try
            {
                using (var ctx = new TestContext()) 
                {
                    alumnos = ctx.Alumno.ToList();
                }
            }
            catch (Exception E)
            { 

                throw;
            }
            return alumnos;
        }

        public Alumno Obtener(int id)
        {
            var alumno = new Alumno();
            try
            {
                using (var ctx = new TestContext())
                {
                    alumno = ctx.Alumno.Where(x => x.id == id)
                                    .SingleOrDefault();
                }
            }
            catch (Exception E)
            {

                throw;
            }
            return alumno;
        }
    }
}
