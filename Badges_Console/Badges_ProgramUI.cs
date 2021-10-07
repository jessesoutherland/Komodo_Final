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
                        PressAnyKeyToContinue();
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
            Console.Clear();

            Badges newb = new Badges();

            Console.WriteLine("Enter the number on the badge:");
            newb.BadgeID = Convert.ToInt32(Console.ReadLine());

            List<string> doors = new List<string>();

            string input1 = default;
            do
            {
                Console.WriteLine("\nEnter a door the badge needs access to:");
                string input = Console.ReadLine().ToUpper();
                doors.Add(input);

                Console.WriteLine("\nAny other doors to add? (y/n)");
                input1 = Console.ReadLine();

                if (input1 == "n")
                {
                    break;
                }

            } while (input1 == "y");
            newb.DoorNames = doors;

            bool wasAdded = _repo.AddNewBadge(newb);

            if (wasAdded)
            {
                Console.WriteLine("\n\nThe badge has been successfully added");
            }
            else
            {
                Console.WriteLine("\nThe badge could not be added. Please try again");
            }

            PressAnyKeyToContinue();
        }

        private void EditMenu()
        {
            Console.Clear();

            ListBadges();

            Console.WriteLine("\n\nEnter the number of the badge you would like to update:");
            int badgeIDInput = Convert.ToInt32(Console.ReadLine());

            Badges targetBadge = _repo.GetBadgeByID(badgeIDInput);
            string doorList = _repo.GetDoorsByID(badgeIDInput);

            Console.Clear();

            Console.WriteLine($"\n{targetBadge.BadgeID} has access to doors {doorList}.");

            Console.WriteLine
                (
                "\n\nWhat would you like to do?\n" +
                "1. Remove a Door\n" +
                "2. Add a Door\n" +
                "3. Return to Main menu"
                );
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    string input1 = default;
                    do
                    {
                        Console.WriteLine("\nWhich door would you like to remove?");
                        string doorRInput = Console.ReadLine().ToUpper();

                        bool wasRemoved = _repo.RemoveDoors(targetBadge.BadgeID, doorRInput);

                        if (wasRemoved)
                        {
                            Console.Clear();
                            Console.WriteLine("Door was removed");
                            string doorList1 = _repo.GetDoorsByID(badgeIDInput);
                            Console.WriteLine($"\n{targetBadge.BadgeID} has access to doors {doorList1}.");
                            
                            Console.WriteLine("\nWould you like to remove another door? (y/n)");
                            input1 = Console.ReadLine();

                            if (input1 == "n")
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThe door could not be removed. Please try again");
                        }
                    } while (input1 == "y");

                    PressAnyKeyToContinue();
                    break;
                case "2":
                    string input2 = default;

                    do
                    {
                        Console.WriteLine("\nPlease enter the door you would like to add:");
                        string doorAInput = Console.ReadLine().ToUpper();

                        bool wasAdded = _repo.AddDoors(targetBadge.BadgeID, doorAInput);

                        if (wasAdded)
                        {
                            Console.Clear();
                            Console.WriteLine("Door was added");
                            string doorList2 = _repo.GetDoorsByID(badgeIDInput);
                            Console.WriteLine($"\n{targetBadge.BadgeID} has access to doors {doorList2}");

                            Console.WriteLine("\nWould you like to add another door? (y/n)");
                            input2 = Console.ReadLine();

                            if (input2 == "n")
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThe door could not be added. Please try again");
                        }

                    } while (input2 == "y");

                    PressAnyKeyToContinue();
                    break;
                case "3":
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("\nPlease enter a valid selection");
                    PressAnyKeyToContinue();
                    break;
            }
        }

        private void ListBadges()
        {
            Console.Clear();

            DisplayAllBadges();
        }

        private void SeedData()
        {
            Badges newb1 = new Badges(12345, new List<string> { "A7" });
            Badges newb2 = new Badges(22345, new List<string> { "A1", "A4", "B1", "B2" });
            Badges newb3 = new Badges(32345, new List<string> { "A4", "A5" });

            _repo.AddNewBadge(newb1);
            _repo.AddNewBadge(newb2);
            _repo.AddNewBadge(newb3);
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        private void DisplayAllBadges()
        {
            Dictionary<int, Badges> listOfBadges = _repo.ShowAllBadges();

            string[] topics = new string[] { "Badge#", "Door Access" };
            Console.WriteLine($"{topics[0],-10}{topics[1]}");

            foreach (KeyValuePair<Int32, Badges> badge in listOfBadges)
            {
                Console.Write($"\n{badge.Key,-10}");
                for (int i = 0; i < badge.Value.DoorNames.Count; i++)
                {
                    Console.Write($"{badge.Value.DoorNames[i]} ");
                }
            }
        }
    }
}
