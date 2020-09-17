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
            Console.WriteLine("Enter user name");
            var name = Console.ReadLine();

            Console.WriteLine("Enter user gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter birthday");
            var birthday = DateTime.Parse(Console.ReadLine()); // TODO: try parse

            Console.WriteLine("Enter weight");
            var weight = Double.Parse(Console.ReadLine());

            Console.WriteLine("Enter height");
            var height = Double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthday, weight, height);
            userController.Save();


        }
    }
}
