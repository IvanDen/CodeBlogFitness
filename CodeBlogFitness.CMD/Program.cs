using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to CodeBlogFitness application!");

            Console.WriteLine("Enter user name: ");
            var name = Console.ReadLine();            

            var userController = new UserController(name);

            if (userController.IsNewUser)
            {
                Console.Write("Enter user gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime(); ;
                var weight = ParseDouble("Weight");
                var height = ParseDouble("Height");
                
                userController.SetNewUserData(gender, birthDate, weight, height);                
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter user Date of birth (dd.mm.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date of birth formats: ");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Invalid {name} formats: ");
                }
            }

        }
    }
}
