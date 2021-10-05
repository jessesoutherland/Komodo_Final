using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges_Console
{
    class Badges_ProgramUI
    {
        private Badges_Repo _repo = new Badges_Repo();

        public void Run()
        {
            SeedData();
            MainMenu();
        }
        private void MainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Komodo Badge Management\n\n");

                Console.WriteLine
                    (
                    "Hello Security Admin, what would you like to do?\n\n" +
                    "1. Add a Badge\n" +
                    "2. Edit a Badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit"
                    );
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateBadge();
                        break;
                    case "2":
                        EditMenu();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nYou have entered an invalid option. Please try again");
                        PressAnyKeyToContinue();
                        break;
                }

            }
        }
        private void CreateBadge()
        {

        }

        private void EditMenu()
        {
            Console.Clear();
            Console.WriteLine
                (
                "What would you like to do?\n" +
                "1. Remove a door\n" +
                "2. Add a door\n" +
                "3. Return to Main menu"
                );
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    RemoveDoor();
                    break;
                case "2":
                    AddDoor();
                    break;
                case "3":
                    MainMenu();
            }
        }
        private void SeedData()
        {

        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
