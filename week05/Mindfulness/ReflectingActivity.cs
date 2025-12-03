
// ReflectingActivity.cs
public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself through this experience?"
    };

    public ReflectingActivity()
        : base("Reflecting Activity",
               "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(7);
            Console.WriteLine();
        }
    }

    private string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        return _questions[new Random().Next(_questions.Count)];
    }
}