namespace Project_PartB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student()
        {
            Assignments = new HashSet<Assignment>();
            Projects = new HashSet<Project>();
        }

        [Key]
        public int s_id { get; set; }

        [Required]
        [StringLength(20)]
        public string first_name { get; set; }

        [Required]
        [StringLength(20)]
        public string last_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_of_birth { get; set; }

        public decimal tuitions_fees { get; set; }

        public int? c_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }

        public virtual Course Courses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }



        public Student(string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees)
        {
            first_name = firstName;
            last_name = lastName;
            date_of_birth = dateOfBirth;
            tuitions_fees = tuitionFees;
        }



        public Student(string firstName, string lastName, DateTime dateOfBirth, decimal tuitionFees, Course course)
        {
            first_name = firstName;
            last_name = lastName;
            date_of_birth = dateOfBirth;
            tuitions_fees = tuitionFees;
            Courses = course;
        }
        public override string ToString()
        {
            return $"ID: {s_id}, first name: {first_name}, last name: {last_name}, date of birth: {date_of_birth}, tuition fees: {tuitions_fees}";
        }
    }
}
