using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Console
{
    class Claims_ProgramUI
    {
        private Claims_Repo _repo = new Claims_Repo();

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

                Console.WriteLine("Komodo Claims Management\n\n");
                Console.WriteLine
                    ("Please select an option:\n\n" +
                    "1. See all claims\n" +
                    "2. Take care of next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit"
                    );
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowClaims();
                        break;
                    case "2":
                        DoNextClaim();
                        break;
                    case "3":
                        AddNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid selection");
                        PressAnyKeyToContinue();
                        break;
                }
            }
        }
        private void ShowClaims()
        {
            Console.Clear();

            DisplayAllClaims();

            PressAnyKeyToContinue();
        }
        private void DoNextClaim()
        {
            Console.Clear();
            
            DisplayClaim();

            Console.WriteLine("\n\nDo you want to deal with this claim now? (y/n)");
            string input = Console.ReadLine();

            if (input == "y")
            {
                _repo._claimsDirectory.Dequeue();
            }
            else if(input == "n")
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("\n\nYou have entered an invalid response. Please type 'y' or 'n'");

                PressAnyKeyToContinue();

                DoNextClaim();
            }
        }
        private void AddNewClaim()
        {
            Console.Clear();

            Claims newClaim = new Claims();

            newClaim.ClaimID = _repo.ShowAllClaims().Last().ClaimID + 1;

            Console.WriteLine("Enter the claim type of either Car, Home or Theft:");
            newClaim.ClaimType = (Console.ReadLine().ToLower());
            if(newClaim.ClaimType != "car")
            {
                if(newClaim.ClaimType != "home")
                {
                    if(newClaim.ClaimType != "theft")
                    {
                        Console.WriteLine("\nYou have entered an invalid response. Please try again");
                        PressAnyKeyToContinue();
                        AddNewClaim();
                    }
                }
            }

            Console.WriteLine("\nEnter a claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("\nAmount of damage:");
            var amount = Console.ReadLine();

            decimal cost = default;

            while (cost == default)
            {
                bool parseSuccess = decimal.TryParse(amount, out cost);
                if (parseSuccess)
                {
                    newClaim.Amount = cost;
                    break;
                }
                else
                {
                    Console.WriteLine("\nThat is not a number. Please try again");
                }
            }
            Console.WriteLine("\nDate of accident:");
            newClaim.DateOfAccident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nDate of claim:");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            bool wasAdded = _repo.AddClaim(newClaim);

            if (wasAdded)
            {
                Console.WriteLine("\n\nThe claim has been successfully added");
            }
            else
            {
                Console.WriteLine("\nThe claim could not be added. Please try again");
            }

            PressAnyKeyToContinue();
        }
        private void PressAnyKeyToContinue()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
        }
        private void SeedData()
        {
            Claims claimOne = new Claims(1, "Car", "Car accident on 465", 400.00m, DateTime.Parse("04-25-2018"), DateTime.Parse("04-27-2018"));
            Claims claimTwo = new Claims(2, "Home", "House fire in kitchen", 4000.00m, DateTime.Parse("04-11-2018"), DateTime.Parse("04-12-2018"));
            Claims claimThree = new Claims(3, "Theft", "Stolen pancakes", 4.00m, DateTime.Parse("04-27-2018"), DateTime.Parse("06-01-2018"));

            _repo.AddClaim(claimOne);
            _repo.AddClaim(claimTwo);
            _repo.AddClaim(claimThree);
        }
        private void DisplayClaim()
        {
            Claims claim = _repo.GetNextClaim();

            Console.WriteLine
                (
                    $"Claim ID: {claim.ClaimID}\n" +
                    $"Type: {claim.ClaimType}\n" +
                    $"Description: {claim.Description}\n" +
                    $"Amount: ${claim.Amount}\n" +
                    $"Date of Accident: {claim.DateOfAccident:MM/dd/yyyy}\n" +
                    $"Date of claim: {claim.DateOfClaim:MM/dd/yyyy}\n" +
                    $"Valid?: {claim.IsValid}\n"
                );
        }
        private void DisplayAllClaims()
        {
            Queue<Claims> listOfClaims = _repo.ShowAllClaims();

            string[] topics = new string[] { "ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid" };
            Console.WriteLine($"{topics[0],-10}{topics[1],-10}{topics[2],-30}{topics[3],-15}{topics[4],-20}{topics[5],-20}{topics[6],-15}");
            foreach (Claims claim in listOfClaims)
            {
                Console.Write($"{claim.ClaimID,-10}{claim.ClaimType,-10}{claim.Description,-30}{claim.Amount,-15}{claim.DateOfAccident,-20:MM/dd/yyyy}{claim.DateOfClaim,-20:MM/dd/yyyy}{claim.IsValid,-15}\n");
            }
        }
    }
}
