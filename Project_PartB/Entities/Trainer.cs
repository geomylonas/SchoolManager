namespace Project_PartB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trainer
    {
        [Key]
        public int t_id { get; set; }

        [Required]
        [StringLength(20)]
        public string first_name { get; set; }

        [Required]
        [StringLength(20)]
        public string last_name { get; set; }

        [Required]
        [StringLength(20)]
        public string subject { get; set; }

        public int? c_id { get; set; }

        public virtual Course Courses { get; set; }

        public Trainer() { }

        public Trainer(string firstName, string lastName, string subject)
        {
            first_name = firstName;
            last_name = lastName;
            this.subject = subject;
        }

        public Trainer(string firstName, string lastName, string subject, Course course)
        {
            first_name = firstName;
            last_name = lastName;
            this.subject = subject;
            Courses = course;
        }



        public override string ToString()
        {
            return $"first name: {first_name}, last name: {last_name}, subject: {subject}";
        }
    }
}
