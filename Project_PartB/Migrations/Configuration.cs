namespace Project_PartB.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project_PartB.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public  void RunSeed()
        {
            Model1 db = new Model1();  
            Configuration configuration = new Configuration();
            configuration.Seed(db);
        }

        protected override void Seed(Project_PartB.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            var courses = new List<Course>
            {
                new Course{title="Introduction to C#",stream="C#",type="Full-time",start_date=new DateTime(2020,3,1),end_date=new DateTime(2020,6,15) },
                new Course{title="Introduction to Javascript",stream="Javascript",type="Full-time",start_date=new DateTime(2020,3,15),end_date=new DateTime(2020,4,15) },
                new Course{title="Sql server and databases",stream="SQL",type="Part-time",start_date=new DateTime(2021,2,10),end_date=new DateTime(2021,6,15) }
            };

            courses.ForEach(c => context.Courses.AddOrUpdate(p => p.title, c));
            context.SaveChanges();

            var trainers = new List<Trainer>
            {
                new Trainer{first_name="John",last_name="Makkas",subject="Javascript",c_id=courses.Single(c=>c.stream=="Javascript").c_id},
                new Trainer{first_name="George",last_name="Nakas",subject="Javascript",c_id=courses.Single(c=>c.stream=="Javascript").c_id},
                new Trainer{first_name="Andronikos",last_name="Maltezos",subject="SQL",c_id=courses.Single(c=>c.stream=="SQL").c_id},
                new Trainer{first_name="Niki",last_name="Nasiou",subject="C#",c_id=courses.Single(c=>c.stream=="C#").c_id}
            };

            trainers.ForEach(t => context.Trainers.AddOrUpdate(p => p.last_name, t));
            context.SaveChanges();

            var students = new List<Student>
            {
                new Student{first_name="George",last_name="Mylonas", date_of_birth=new DateTime(1980,8,8),tuitions_fees=2500,c_id=courses.Single(c=>c.stream=="C#").c_id},
                new Student{first_name="George",last_name="Zikos", date_of_birth=new DateTime(1976,5,2),tuitions_fees=2100,c_id=courses.Single(c=>c.stream=="C#").c_id},
                new Student{first_name="Andreas",last_name="Kallianiotis", date_of_birth=new DateTime(1995,11,1),tuitions_fees=3500,c_id=courses.Single(c=>c.stream=="C#").c_id},
                new Student{first_name="Eleni",last_name="Sotiropoulou", date_of_birth=new DateTime(1985,8,15),tuitions_fees=1500,c_id=courses.Single(c=>c.stream=="Javascript").c_id},
                new Student{first_name="Tzeni",last_name="Saraliotou", date_of_birth=new DateTime(2000,1,1),tuitions_fees=4500,c_id=courses.Single(c=>c.stream=="Javascript").c_id},
                new Student{first_name="Dimitris",last_name="Stratsianis", date_of_birth=new DateTime(1980,9,12),tuitions_fees=2250,c_id=courses.Single(c=>c.stream=="SQL").c_id},
                new Student{first_name="Kostas",last_name="Glikas", date_of_birth=new DateTime(1992,10,12),tuitions_fees=2500,c_id=courses.Single(c=>c.stream=="SQL").c_id},
            };

            students.ForEach(s => context.Students.AddOrUpdate(p => p.last_name, s));
            context.SaveChanges();

            var assignments = new List<Assignment>
            {
                new Assignment{title="Intro to C#",description="first assignment in c#",sub_date_time=new DateTime(2021,10,1),oral_mark=2,total_mark=8,s_id=students.Single(s=>s.last_name=="Mylonas").s_id},
                new Assignment{title="ASP.NET and C#",description="second assignment in c#",sub_date_time=new DateTime(2021,11,20),oral_mark=3,total_mark=8,s_id=students.Single(s=>s.last_name=="Mylonas").s_id},
                new Assignment{title="Intro to C#",description="first assignment in c#",sub_date_time=new DateTime(2021,10,1),oral_mark=1,total_mark=6,s_id=students.Single(s=>s.last_name=="Zikos").s_id},
                new Assignment{title="Intro to C#",description="first assignment in c#",sub_date_time=new DateTime(2021,10,1),oral_mark=1,total_mark=6,s_id=students.Single(s=>s.last_name=="Kallianiotis").s_id},
                new Assignment{title="Javascript Basics",description="Introduction to Javascript syntax",sub_date_time=new DateTime(2021,10,10),oral_mark=4,total_mark=10,s_id=students.Single(s=>s.last_name=="Sotiropoulou").s_id},
                new Assignment{title="Arrow functions",description="Anonymous javascript functions",sub_date_time=new DateTime(2021,10,5),oral_mark=2,total_mark=8,s_id=students.Single(s=>s.last_name=="Saraliotou").s_id},
                new Assignment{title="SQL Server",description="Design of relational databases and SQL Server",sub_date_time=new DateTime(2021,10,20),oral_mark=4,total_mark=9,s_id=students.Single(s=>s.last_name=="Stratsianis").s_id},
                new Assignment{title="TSQL basics",description="Triggers and procedures on SQL Server",sub_date_time=new DateTime(2021,11,20),oral_mark=4,total_mark=10,s_id=students.Single(s=>s.last_name=="Glikas").s_id},

            };

            assignments.ForEach(a => context.Assignments.AddOrUpdate(p => new { p.title, p.s_id }, a));
            context.SaveChanges();


            var projects = new List<Project>
            {

                new Project{title="project-part A",description="individual project  in c#",sub_date_time=new DateTime(2021,10,5),oral_mark=2,total_mark=9,type="Individual",s_id=students.Single(s=>s.last_name=="Mylonas").s_id},
                new Project{title="Web application",description="An eshop web app",sub_date_time=new DateTime(2021,11,29),oral_mark=4,total_mark=9,type="Team",s_id=students.Single(s=>s.last_name=="Mylonas").s_id},
                new Project{title="project-part B",description="individual project  in c#",sub_date_time=new DateTime(2021,11,15),oral_mark=3,total_mark=9,type="Individual",s_id=students.Single(s=>s.last_name=="Zikos").s_id},
                new Project{title="Web app",description="web app with Javascript",sub_date_time=new DateTime(2021,11,18),oral_mark=3,total_mark=8,type="Team",s_id=students.Single(s=>s.last_name=="Saraliotou").s_id},

            };

            projects.ForEach(pr => context.Projects.AddOrUpdate(p => new { p.title, p.s_id }, pr));
            context.SaveChanges();

        }
    }
}
