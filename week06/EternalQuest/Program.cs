using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
        const string ETERNALQUEST = "eternalQuestData.txt";
        QuestManager manager = new QuestManager();
        
        
        manager.LoadGoals(ETERNALQUEST);
        
        string choice = "";
        
        do
        {
            Console.WriteLine("\n==================================");
            manager.DisplayPlayerInfo();
            Console.WriteLine("==================================");
            
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.ListGoalDetails();
                    break;
                case "3":
                    manager.RecordEvent();
                    break;
                case "4":
                    manager.SaveGoals(ETERNALQUEST);
                    break;
                case "5":
                    manager.LoadGoals(ETERNALQUEST);
                    break;
                case "6":
                    Console.WriteLine("\nThank you for embarking on your Eternal Quest. Goodbye!");
                    
                    manager.SaveGoals(ETERNALQUEST); 
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please choose a number from the menu.");
                    break;
            }
        } while (choice != "6");
    }
}
