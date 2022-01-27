using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PartB.Services
{
    class CourseService : IAccessible
    {
        Model1 context = new Model1();

        public void Print()
        {
            Console.WriteLine(string.Join("\n", context.Courses.Select(c => c)));
        }

        public void Insert()
        {
            string title, stream, type;
            DateTime startDate, endDate;

            try
            {
                Console.WriteLine("Give title");
                title = Console.ReadLine();
                Console.WriteLine("Give stream");
                stream = Console.ReadLine();
                Console.WriteLine("Give start Date (yyyy-mm-dd)");
                startDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Give end Date (yyyy-mm-dd)");
                endDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Give type");
                type = Console.ReadLine();

                context.Courses.Add(new Course(title, stream, startDate, endDate, type));
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error: " + ex.Message);
            }

        }
    }
}
