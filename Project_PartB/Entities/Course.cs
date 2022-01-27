namespace Project_PartB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Students = new HashSet<Student>();
            Trainers = new HashSet<Trainer>();
        }

        [Key]
        public int c_id { get; set; }

        [Required]
        [StringLength(50)]
        public string title { get; set; }

        [Required]
        [StringLength(20)]
        public string stream { get; set; }

        [Required]
        [StringLength(20)]
        public string type { get; set; }

        [Column(TypeName = "date")]
        public DateTime start_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime end_date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Trainer> Trainers { get; set; }

        public Course(string title, string stream, DateTime startDate, DateTime endDate, string type)
        {
            this.title = title;
            this.stream = stream;
            start_date = startDate;
            end_date = endDate;
            this.type = type;
        }

        public override string ToString()
        {
            return $"ID: {c_id}, title: {title}, stream: {stream}, type: {type}, start date: {start_date}, end date: {end_date}";
        }
    }
}
