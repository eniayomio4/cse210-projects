

public class SimpleGoal : Goal
{
    private bool _isComplete;
    private const int TYPE_ID = 1; 

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

   
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

   
    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"\nCongratulations! You have completed the goal: **{ShortName}**!");
            Console.WriteLine($"You earned {Points} points!");
        }
        else
        {
            Console.WriteLine($"\n**{ShortName}** is already complete and cannot be recorded again.");
        }
    }

    
    public override bool IsComplete()
    {
        return _isComplete;
    }

    
    public override string GetDetailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {base.GetDetailsString()}";
    }

    
    public override string GetStringRepresentation()
    {
       
        return $"{TYPE_ID}|{ShortName}|{description}|{Points}|{_isComplete}";
    }
}