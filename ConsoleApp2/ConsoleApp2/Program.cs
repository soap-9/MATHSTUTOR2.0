using System;

namespace eman2004
{
    class Program
    {
        static void Main(string[] args)
        {
            var tutorial = new Tutorial();
            var game = new Game();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MathsTutor ===");
                Console.WriteLine("1. Instructions");
                Console.WriteLine("2. Deal 3 cards");
                Console.WriteLine("3. Quit");
                Console.Write("Select an option: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        tutorial.ShowInstructions();
                        Console.WriteLine("Press any key to return to the main menu...");
                        Console.ReadKey(true);
                        break;

                    case "2":
                        Console.Clear();
                        game.PlayGame();
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Press any key to try again...");
                        Console.ReadKey(true);
                        break;
                }
            }
        }
    }
}