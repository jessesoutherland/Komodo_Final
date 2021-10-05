using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class Cafe
    {
        public Cafe() { }

        public Cafe(string mealName, int mealNumber, string description, string ingredients, decimal price)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }

        public string MealName { get; set; }
        public int MealNumber { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }
    }
}
