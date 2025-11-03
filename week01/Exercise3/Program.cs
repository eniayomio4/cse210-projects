using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 101);
        int guess = -1;
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            if (guess > number)
            {
                Console.Write("Lower");
            }
            else if (guess < number)
            {
                Console.Write("Higher");
            }
            else
            {
                Console.Write("You guessed it!");
            }
        } while (number != guess);
    }
}