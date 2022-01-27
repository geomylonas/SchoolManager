using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PartB.Services
{
    class ProjectService : IAccessible, IAccessiblePerCourse, IAccessiblePerStudentPerCourse
    {
        Model1 context = new Model1();

        public void Print()
        {
            Console.WriteLine(string.Join("\n", context.Projects.Select(p => p)));
        }

        public void PrintPerCourse()
        {

            foreach (var course in context.Courses)
            {
                Console.WriteLine($"Course: {course.title}");
                Console.WriteLine(string.Join("\n", course.Students.Join(context.Projects, s => s.s_id, p => p.s_id, (s, p) => p)));
                Console.WriteLine();
            }
        }

        public void PrintPerStudentPerCourse()
        {
            foreach (var course in context.Courses)
            {
                Console.WriteLine($"Course: {course.title}");
                Console.WriteLine(string.Join("\n", course.Students.Join(context.Projects, s => s.s_id, p => p.s_id, (s, p) => new
                {
                    firstName = s.first_name,
                    lastName = s.last_name,
                    p
                }
                ))); ;
                Console.WriteLine();
            }

        }


        public void Insert()
        {
            string title, description, type;
            DateTime subDateTime;
            int oralMark, totalMark;
            try
            {
                Console.WriteLine("Give title");
                title = Console.ReadLine();
                Console.WriteLine("Give description");
                description = Console.ReadLine();
                Console.WriteLine("Give type");
                type = Console.ReadLine();
                Console.WriteLine("Give date of submission (yyyy-mm-dd)");
                subDateTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Give oral mark");
                oralMark = int.Parse(Console.ReadLine());
                Console.WriteLine("Give total mark");
                totalMark = int.Parse(Console.ReadLine());

                context.Projects.Add(new Project(title, description, subDateTime, oralMark, totalMark, type));
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

        }


        public void InsertPerCourse()
        {
            int courseId, studentId;
            Student student;
            Course course;
            string title, description, type;
            DateTime subDateTime;
            int oralMark, totalMark;
            CourseService courseService = new CourseService();

            try
            {
                courseService.Print();
                Console.WriteLine();
                Console.WriteLine("Choose Course (ID)");
                courseId = int.Parse(Console.ReadLine());
                course = context.Courses.Where(c => c.c_id == courseId).Single();

                Console.WriteLine(string.Join("\n", course.Students.Select(s => s)));
                Console.WriteLine();
                Console.WriteLine("Choose Student (ID)");
                studentId = int.Parse(Console.ReadLine());
                student = context.Students.Where(S => S.s_id == studentId).Single();

                Console.WriteLine();
                Console.WriteLine("Give title");
                title = Console.ReadLine();
                Console.WriteLine("Give description");
                description = Console.ReadLine();
                Console.WriteLine("Give type");
                type = Console.ReadLine();
                Console.WriteLine("Give date of submission (yyyy-mm-dd)");
                subDateTime = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Give oral mark");
                oralMark = int.Parse(Console.ReadLine());
                Console.WriteLine("Give total mark");
                totalMark = int.Parse(Console.ReadLine());

                context.Projects.Add(new Project(title, description, subDateTime, oralMark, totalMark, type, student));
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }
        }





    }
}
