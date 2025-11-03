using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int response = -1;
        do
        {
            Console.Write("Enter number: ");
            response = int.Parse(Console.ReadLine());
            if (response != 0)
            {
                numbers.Add(response);
            }

        } while (response != 0);

        float sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        int count = numbers.Count;
        float average = sum / count;
        int largest = numbers.Max();
        Console.Write($"The sum is: {sum}\n");
        Console.Write($"The average is: {average:F4}\n");
        Console.Write($"The largest number is: {largest}\n");
    }
}