
// ChecklistGoal.cs

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonusPoints;
    private const int TYPE_ID = 3; 

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonusPoints = bonus;
    }


    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonusPoints = bonus;
    }

    
    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"\nEvent recorded for **{ShortName}**!");
            Console.WriteLine($"You earned {Points} points!");

            if (_amountCompleted == _target)
            {
                
                Console.WriteLine($"*** Goal Completed! You earned a bonus of {_bonusPoints} points! ***");
            }
        }
        else
        {
            Console.WriteLine($"\n**{ShortName}** has already reached its target of {_target}.");
        }
    }

    
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }


    public override string GetDetailsString()
    {
        string statusMark = IsComplete() ? "X" : " ";
        return $"[{statusMark}] {base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    
    public override string GetStringRepresentation()
    {
        
        return $"{TYPE_ID}|{ShortName}|{description}|{Points}|{_bonusPoints}|{_target}|{_amountCompleted}";
    }
    
    
    public int BonusPoints => _bonusPoints;
}