using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PartB.Services
{
    class StudentService : IAccessible, IAccessiblePerCourse
    {
        Model1 context = new Model1();

        public void Print()
        {
            Console.WriteLine(string.Join("\n", context.Students.Select(s => s)));
        }


        public void PrintPerCourse()
        {

            foreach (var course in context.Courses)
            {
                Console.WriteLine($"Course: {course.title}");
                Console.WriteLine(string.Join("\n", course.Students.Select(s => s)));
                Console.WriteLine();
            }
        }

        public void Insert()
        {
            string firstName, lastName;
            DateTime dateOfBirth;
            decimal tuitionFees;
            try
            {
                Console.WriteLine("Give first name");
                firstName = Console.ReadLine();
                Console.WriteLine("Give last name");
                lastName = Console.ReadLine();
                Console.WriteLine("Give date of birth (yyyy-mm-dd)");
                dateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Give tuition fees");
                tuitionFees = decimal.Parse(Console.ReadLine());

                context.Students.Add(new Student(firstName, lastName, dateOfBirth, tuitionFees));
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
            string firstName, lastName;
            DateTime dateOfBirth;
            decimal tuitionFees;
            CourseService courseService = new CourseService();

            try
            {
                courseService.Print();
                Console.WriteLine();
                Console.WriteLine("Choose Course (ID)");
                courseId = int.Parse(Console.ReadLine());
                course = context.Courses.Where(c => c.c_id == courseId).Single();
                Console.WriteLine();

                Console.WriteLine("Give first name");
                firstName = Console.ReadLine();
                Console.WriteLine("Give last name");
                lastName = Console.ReadLine();
                Console.WriteLine("Give date of birth (yyyy-mm-dd)");
                dateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Give tuition fees");
                tuitionFees = decimal.Parse(Console.ReadLine());

                context.Students.Add(new Student(firstName, lastName, dateOfBirth, tuitionFees, course));
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }
        }
    }
}
