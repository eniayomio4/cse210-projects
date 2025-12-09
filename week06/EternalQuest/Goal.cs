
public abstract class Goal
{
    
    private string _shortName;
    private string _description;
    private int _points;

   
    public string ShortName => _shortName;
    public int Points => _points;
    public string description => _description;

  
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

  
    public abstract void RecordEvent();

        public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    
    public abstract string GetStringRepresentation();

   
    public abstract bool IsComplete();
}