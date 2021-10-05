using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class Cafe_Repo
    {
        private readonly List<Cafe> _menuDirectory = new List<Cafe>();

         //Create
         public bool AddItemToMenu(Cafe item)
        {
            int startingCount = _menuDirectory.Count;

            _menuDirectory.Add(item);

            bool wasAdded = (_menuDirectory.Count > startingCount) ? true : false;

            return wasAdded;
        }

        //Read
        public List<Cafe> SeeMenu()
        {
            return _menuDirectory;
        }

        //Delete
        public bool DeleteItem(int number)
        {
            Cafe item = GetItemByNumber(number);

            if(item != null)
            {
                int initialCount = _menuDirectory.Count;
                _menuDirectory.Remove(item);

                if(initialCount > _menuDirectory.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        //Helper Method
        public Cafe GetItemByNumber(int number)
        {
            foreach(Cafe item in _menuDirectory)
            {
                if(item.MealNumber == number)
                {
                    return item;
                }
            
            }
            
            return null;
        }
    }
}
