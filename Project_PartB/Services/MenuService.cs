using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PartB.Services
{
    class MenuService
    {
        CourseService CourseService;
        StudentService StudentService;
        TrainerService TrainerService;
        AssignmentService AssignmentService;
        ProjectService ProjectService;

        public MenuService()
        {
            CourseService = new CourseService();
            StudentService = new StudentService();
            TrainerService = new TrainerService();
            AssignmentService = new AssignmentService();
            ProjectService = new ProjectService();
        }




        public void start()
        {
            int choice;


            Console.WriteLine("Welcome to PeopleCert Training Camp");

            do
            {
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("1. Print Data");
                Console.WriteLine("2. Insert Data");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Make a choice (1-2)");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PrintData();
                        break;
                    case 2:
                        InsertData();
                        break;
                    default:
                        break;
                }
            } while (choice != 0);
        }


        public void PrintData()
        {
            int choice;
            Console.Clear();
            Console.WriteLine("1. Print Courses");
            Console.WriteLine("2. Print Students");
            Console.WriteLine("3. Print Trainers");
            Console.WriteLine("4. Print Assignments Per Course");
            Console.WriteLine("5. Print Projects Per Course");
            Console.WriteLine("6. Print Students Per Course");
            Console.WriteLine("7. Print Trainers Per Course");
            Console.WriteLine("8. Print Assignments Per Student Per Course");
            Console.WriteLine("9. Print Projects Per Student Per Course");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Make a choice (0-9)");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    CourseService.Print();
                    break;
                case 2:
                    StudentService.Print();
                    break;
                case 3:
                    TrainerService.Print();
                    break;
                case 4:
                    AssignmentService.PrintPerCourse();
                    break;
                case 5:
                    ProjectService.PrintPerCourse();
                    break;
                case 6:
                    StudentService.PrintPerCourse();
                    break;
                case 7:
                    TrainerService.PrintPerCourse();
                    break;
                case 8:
                    AssignmentService.PrintPerStudentPerCourse();
                    break;
                case 9:
                    ProjectService.PrintPerStudentPerCourse();
                    break;
                default:
                    break;
            }

        }

        public void InsertData()
        {
            int choice;

            Console.Clear();
            Console.WriteLine("1. Insert Course");
            Console.WriteLine("2. Insert Student");
            Console.WriteLine("3. Insert Trainer");
            Console.WriteLine("4. Insert Student Per Course");
            Console.WriteLine("5. Insert Trainer Per Course");
            Console.WriteLine("6. Insert Assignments Per Student Per Course");
            Console.WriteLine("7. Insert Projects Per Student Per Course");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Make a choice (0-7)");
            choice = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (choice)
            {
                case 1:
                    CourseService.Insert();
                    break;
                case 2:
                    StudentService.Insert();
                    break;
                case 3:
                    TrainerService.Insert();
                    break;
                case 4:
                    StudentService.InsertPerCourse();
                    break;
                case 5:
                    TrainerService.InsertPerCourse();
                    break;
                case 6:
                    AssignmentService.InsertPerCourse();
                    break;
                case 7:
                    ProjectService.InsertPerCourse();
                    break;
                default:
                    break;

            }

        }


    }
}
