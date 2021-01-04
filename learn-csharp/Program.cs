using System;

namespace myApp
{
    class Program
    {
        // This is a method called "main"
        // Our program starts from here
        static void Main(string[] args)
        {
            // Program.Calculator(args);
            // Program.AnotherMethod(args);
            Program.YourName(args);
        }

       static void YourName(string[] args)
       {
           Console.WriteLine("What is your first name? ");
           string firstName = Console.ReadLine();
           Console.WriteLine("What is your last name? ");
           string secondName = Console.ReadLine();
           Console.WriteLine("Welcome, " + firstName + " " + secondName);
       }
       
       static void Calculator(string[] args) {
            Console.Write("Type your first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Type your second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("The sum of the two numbers is: ");
            int sumOfNumbers = firstNumber + secondNumber;
            Console.WriteLine(sumOfNumbers);
       }

       static void AnotherMethod(string[] args) {
           // something else
       }
    
    }
}
