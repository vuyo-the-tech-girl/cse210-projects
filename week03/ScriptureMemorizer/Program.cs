using System;

class Program
{
    static void Main(string[] args)
    {
        Reference ref1 = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(ref1, "For God so loved the word that he gave his only begotten Son");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.ToString());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            Console.Write("Press Enter to hide words or type 'quit' to exit:");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
               break;

            scripture.HideRandomWords(3);   
        }
    }
}