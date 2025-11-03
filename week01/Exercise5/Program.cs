using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

            DisplayMessage();

            string userName = PromptUserName();
            int userNumber = PromptUserNumber();

            int square = SquareNumber(userNumber);

            DisplayResult(userName, square);

        static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.WriteLine("Please enter your name: ");
            string userInput = Console.ReadLine();
            return userInput;
        }

        static int PromptUserNumber()
        {
            Console.WriteLine("Please enter your favorite number: ");
            int userInput = int.Parse(Console.ReadLine());
            return userInput;
        }

        static int SquareNumber(int userNumber)
        {
            int square = userNumber * userNumber;
            return square;
        }

        static void DisplayResult(string userName, int SquareNumber)
        {
            Console.WriteLine($"{userName}, the square of your number is {SquareNumber}");
        }
    }
}