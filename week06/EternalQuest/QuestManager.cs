
using System.Collections.Generic;
using System.IO;
using System;

public class QuestManager
{

    private List<Goal> _goals = new List<Goal>();
    private int _score;
    private string _currentLevel;

   
    public int Score => _score;

  
    public QuestManager()
    {
        _score = 0;
        _currentLevel = "Level 1: Beginner Seeker";
    }

 

   
    public void DisplayPlayerInfo()
    {
        
        if (_score >= 5000) _currentLevel = "Level 10: Eternal Quest Master";
        else if (_score >= 2500) _currentLevel = "Level 7: Valiant Voyager";
        else if (_score >= 1000) _currentLevel = "Level 4: Dedicated Disciple";

        Console.WriteLine("\n*** Player Status ***");
        Console.WriteLine($"Current Score: **{_score} points**");
        Console.WriteLine($"Current Rank: **{_currentLevel}**");
        Console.WriteLine("*********************");
    }

 
    public void CreateGoal()
    {
        Console.WriteLine("\nWhich type of goal would you like to create?");
        Console.WriteLine("  1. Simple Goal (one-time completion)");
        Console.WriteLine("  2. Eternal Goal (never-ending progress)");
        Console.WriteLine("  3. Checklist Goal (complete X times for a bonus)");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus points for finishing it? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation cancelled.");
                return;
        }
        Console.WriteLine($"\nGoal **{name}** created successfully!");
    }


    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals have been created yet.");
            return;
        }

        Console.WriteLine("\n*** Your Goals ***");
        for (int i = 0; i < _goals.Count; i++)
        {
           
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine("******************");
    }

 
    public void RecordEvent()
    {
        ListGoalDetails();
        if (_goals.Count == 0) return;

        Console.Write("Which goal did you accomplish? Enter the number: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];
            bool wasCompleteBefore = goal.IsComplete();

            
            goal.RecordEvent();

           
            _score += goal.Points;

          
            if (goal is ChecklistGoal checklistGoal && !wasCompleteBefore && checklistGoal.IsComplete())
            {
                
                _score += checklistGoal.BonusPoints;
            }

            DisplayPlayerInfo(); 
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

 

    public void SaveGoals(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
               
                outputFile.WriteLine(_score);

                
                foreach (Goal goal in _goals)
                {
                    
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"\nGoals and score saved to **{filename}** successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving: {ex.Message}");
        }
    }

    
    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nFile **{filename}** not found. Starting with a new quest.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            
            _score = int.Parse(lines[0]);

            _goals.Clear(); 

          
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split('|');
                int typeId = int.Parse(parts[0]);
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                Goal newGoal = null;

                switch (typeId)
                {
                    case 1:
                        bool isComplete = bool.Parse(parts[4]);
                        newGoal = new SimpleGoal(name, description, points, isComplete);
                        break;
                    case 2: 
                        newGoal = new EternalGoal(name, description, points);
                        break;
                    case 3: 
                        int bonus = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int amountCompleted = int.Parse(parts[6]);
                        newGoal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                        break;
                }

                if (newGoal != null)
                {
                    _goals.Add(newGoal);
                }
            }
            Console.WriteLine($"\nGoals and score loaded from **{filename}** successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading. Data may be corrupted: {ex.Message}");
            _score = 0;
            _goals.Clear();
        }
    }
}