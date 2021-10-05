using Cafe_Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cafe_Tests
{
    [TestClass]
    public class Cafe_Tests
    {
        private Cafe _item;
        private Cafe_Repo _repo;

        [TestInitialize]
        public void SeedData()
        {
            _item = new Cafe("PB&J", 1, "An American classic!", "Peanuts, Butter, Jelly", 10.99m);
            _repo = new Cafe_Repo();

            _repo.AddItemToMenu(_item);
        }

        [TestMethod]
        public void AddItem_ShouldGetNotNull()
        {
            Cafe item = new Cafe();
            item.MealNumber = 1;
            Cafe_Repo repo = new Cafe_Repo();

            repo.AddItemToMenu(item);
            Cafe itemFromDirectory = repo.GetItemByNumber(1);

            Assert.IsNotNull(itemFromDirectory);
        }

        [TestMethod]
        public void ShowMenu_ShouldReturnAllItems()
        {
            List<Cafe> showItems = _repo.SeeMenu();

            Assert.IsNotNull(showItems);

        }

        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            bool deleteItem = _repo.DeleteItem(_item.MealNumber);

            Assert.IsTrue(deleteItem);
        }
    }
}
