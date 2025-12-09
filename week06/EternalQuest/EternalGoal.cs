

public class EternalGoal : Goal
{
    private const int TYPE_ID = 2; 

    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

  
    public override void RecordEvent()
    {
        Console.WriteLine($"\nEvent recorded for **{ShortName}**!");
        Console.WriteLine($"You earned {Points} points!");
        
    }

    
    public override bool IsComplete()
    {
        return false;
    }

    
    public override string GetStringRepresentation()
    {
       
        return $"{TYPE_ID}|{ShortName}|{description}|{Points}";
    }
}