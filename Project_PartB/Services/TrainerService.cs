using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PartB.Services
{
    class TrainerService : IAccessible, IAccessiblePerCourse
    {
        Model1 context = new Model1();

        public void Print()
        {
            Console.WriteLine(string.Join("\n", context.Trainers.Select(t => t)));
        }

        public void PrintPerCourse()
        {

            foreach (var course in context.Courses)
            {
                Console.WriteLine($"Course: {course.title}");
                Console.WriteLine(string.Join("\n", course.Trainers.Select(s => s)));
                Console.WriteLine();
            }
        }

        public void Insert()
        {
            string firstName, lastName, subject;
            try
            {
                Console.WriteLine("Give first name");
                firstName = Console.ReadLine();
                Console.WriteLine("Give last name");
                lastName = Console.ReadLine();
                Console.WriteLine("Give subject");
                subject = Console.ReadLine();
                context.Trainers.Add(new Trainer(firstName, lastName, subject));
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }
        }


        public void InsertPerCourse()
        {
            int courseId;
            Course course;
            string firstName, lastName, subject;
            CourseService courseService = new CourseService();

            try
            {
                courseService.Print();
                Console.WriteLine();
                Console.WriteLine("Choose Course (ID)");
                courseId = int.Parse(Console.ReadLine());
                Console.WriteLine();
                course = context.Courses.Where(c => c.c_id == courseId).Single();
                Console.WriteLine("Give first name");
                firstName = Console.ReadLine();
                Console.WriteLine("Give last name");
                lastName = Console.ReadLine();
                Console.WriteLine("Give subject");
                subject = Console.ReadLine();
                context.Trainers.Add(new Trainer(firstName, lastName, subject, course));
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }
        }
    }
}
