using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class Cafe_ProgramUI
    {
        private Cafe_Repo _repo = new Cafe_Repo();

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

                Console.WriteLine("Komodo Cafe Menu Management\n\n");
                Console.WriteLine
                    (
                        "Please select an option below:\n\n" +
                        "1. See all menu items\n" +
                        "2. Add an item to the menu\n" +
                        "3. Remove an item from the menu\n" +
                        "4. Exit"
                    );
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowMenu();
                        break;
                    case "2":
                        AddItems();
                        break;
                    case "3":
                        RemoveItems();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("You have made an invalid selection. Let's try that again.");
                        PressAnyKeyToContinue();
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.Clear();

            List<Cafe> listOfItems = _repo.SeeMenu();

            foreach(Cafe item in listOfItems)
            {
                DisplayItems(item);
            }

            PressAnyKeyToContinue();
        }

        private void AddItems()
        {
            Console.Clear();

            Cafe newItem = new Cafe();

            newItem.MealNumber = _repo.SeeMenu().Last().MealNumber + 1;

            Console.WriteLine("Enter the name of the item you would like to add:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("\n\nEnter the description of the new item:");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("\n\nEnter the ingredients of the new item. Place a comma between each ingredient:");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("\n\nEnter the price of the new item:");
            newItem.Price = Convert.ToDecimal(Console.ReadLine());

            bool wasAdded = _repo.AddItemToMenu(newItem);

            if (wasAdded)
            {
                Console.WriteLine("\n\nThe item has been successfully added");
            }
            else
            {
                Console.WriteLine("\nThe item could not be added. Please try again");
            }

            PressAnyKeyToContinue();

        }

        private void RemoveItems()
        {
            Console.Clear();

            ShowMenu();

            Console.WriteLine("\n\nEnter the number of the item you would like to remove:");
            int userInput = Convert.ToInt16(Console.ReadLine());

            Cafe targetItem = _repo.GetItemByNumber(userInput);

            if (targetItem == null)
            {
                Console.WriteLine("\n\nUnable to find selection. Please try again");
                PressAnyKeyToContinue();
                return;
            }

            bool wasRemoved = _repo.DeleteItem(userInput);

            if (wasRemoved)
            {
                Console.WriteLine("\n\nThe item was successfully removed");
            }
            else
            {
                Console.WriteLine("\nThe item could not be removed. Please try again");
            }

            PressAnyKeyToContinue();
        }

        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }

        private void DisplayItems(Cafe item)
        {
            Console.WriteLine
                (
                    $"#{item.MealNumber}: {item.MealName} - ${item.Price}\n" +
                    $"{item.Description}\n\n" +
                    $"Ingredients:\n{item.Ingredients}\n\n"
                );
        }

        private void SeedData()
        {                                                                                          
            Cafe itemOne = new Cafe("PB&J", 1, "A clssic sandwich loved by all...except weirdos.", "Peanuts, Butter, Jelly", 5.99m);
            Cafe itemTwo = new Cafe("Meatloaf", 2, "Just like mom used to make, except good!", "Beef, Ketchup, Onions, Egg, Milk", 10.99m);
            Cafe itemThree = new Cafe("Cheeseburger", 3, "The best damn food ever created. Fight me.", "Beef, Cheese, Bun, Optional toppings", 9.99m);

            _repo.AddItemToMenu(itemOne);
            _repo.AddItemToMenu(itemTwo);
            _repo.AddItemToMenu(itemThree);
        }
    }
}
