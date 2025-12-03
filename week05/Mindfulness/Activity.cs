
// Activity.cs
public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine($"Starting {_name}...\n");
        ShowReadyAnimation();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine() ?? "30");
        Console.WriteLine("\nGet ready...");
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\n\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed the {_name}.");
        Console.WriteLine($"Duration: {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            foreach (string s in spinner)
            {
                Console.Write(s);
                Thread.Sleep(200);
                Console.Write("\b \b");
            }
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void ShowReadyAnimation()
    {
        ShowSpinner(4);
    }

    // Each derived class must implement its own unique behavior
    protected abstract void PerformActivity();
}