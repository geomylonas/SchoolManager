namespace Project_PartB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project
    {
        [Key]
        public int p_id { get; set; }

        [Required]
        [StringLength(20)]
        public string title { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }

        public DateTime sub_date_time { get; set; }

        public int oral_mark { get; set; }

        public int total_mark { get; set; }

        [Required]
        [StringLength(20)]
        public string type { get; set; }

        public int s_id { get; set; }

        public virtual Student Students { get; set; }


        public Project() { }

        public Project(string title, string description, DateTime subDateTime, int oralMark, int totalMark, string type)
        {
            this.title = title;
            this.description = description;
            sub_date_time = subDateTime;
            oral_mark = oralMark;
            total_mark = totalMark;
            this.type = type;
        }

        public Project(string title, string description, DateTime subDateTime, int oralMark, int totalMark, string type, Student student)
        {
            this.title = title;
            this.description = description;
            sub_date_time = subDateTime;
            oral_mark = oralMark;
            total_mark = totalMark;
            this.type = type;
            Students = student;
        }



        public override string ToString()
        {
            return $"title: {title}, description: {description}, sub date time: {sub_date_time}, oral mark: {oral_mark}, total mark: {total_mark}, type: {type}";
        }
    }
}
