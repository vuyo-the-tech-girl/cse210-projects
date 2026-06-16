using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static int _score = 0;
    static List<Goal> _goals = new List<Goal>();
    
    static void Main(string[] args)
    {
        int choice = 0;
        
        while (choice!= 7)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Display Score");
            Console.WriteLine("7. Quit");
            Console.Write("Select a choice: ");
            
            choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: DisplayScore(); break;
            }
        } 
    }
    
    static void DisplayPlayerInfo()
    {
        Console.Clear();
        Console.WriteLine($"You have {_score} points.\n");
    }
    
    static void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int type = int.Parse(Console.ReadLine());
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string desc = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        
        if (type == 1)
        _goals.Add(new SimpleGoal(name, desc, points));
        else if (type == 2)
        _goals.Add(new EternalGoal(name, desc, points));
        else if (type == 3)
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }
    
    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }  
    
    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        }
    }
    
    static void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved!");
    }
    
    static void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        string[] lines = File.ReadAllLines(filename);
        
        _score = int.Parse(lines[0]);
        _goals.Clear();
        
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            string[] typeParts = parts[0].Split(':');
            string type = typeParts[0];
            string name = typeParts[1];
            
            if (type == "SimpleGoal")
            {
                SimpleGoal g = new SimpleGoal(name, parts[1], int.Parse(parts[2]));
                if (bool.Parse(parts[3])) g.RecordEvent();
                _goals.Add(g);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(name, parts[1], int.Parse(parts[2])));
            }
            else if (type == "ChecklistGoal")
            {
                ChecklistGoal g = new ChecklistGoal(name, parts[1], int.Parse(parts[2]), int.Parse(parts[4]), int.Parse(parts[3]));
                for (int j = 0; j < int.Parse(parts[5]); j++) g.RecordEvent();
                _goals.Add(g);
            }
        }
        Console.WriteLine("Goals loaded!");
    }
    
    static void DisplayScore() => Console.WriteLine($"Current score: {_score} points");
}