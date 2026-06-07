using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            
            Activity activity = null;
            
            if (choice == "1")
            activity = new BreathingActivity();
            else if (choice == "2")
            activity = new ReflectionActivity();
            else if (choice == "3")
            activity = new ListingActivity();
            else if (choice == "4")
            break;
            else
            {
                Console.WriteLine("Invalid choice. Press enter to try again.");
                Console.ReadLine();
                continue;
            }
            
            activity.Run();
        }
    }
}