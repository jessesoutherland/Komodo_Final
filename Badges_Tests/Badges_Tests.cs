using Badges_Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Badges_Tests
{
    [TestClass]
    public class Badges_Tests
    {
        private Badges_Repo _repo;
        private List<string> _doorListOne = new List<string> { "A1", "A2" };
        private List<string> _doorListTwo = new List<string> { "B3", "B4" };

        [TestInitialize] //This tests AddNewBadge
        public void Arrange()
        {
            _repo = new Badges_Repo();
            Badges newb1 = new Badges(1234, _doorListOne);
            Badges newb2 = new Badges(5678, _doorListTwo);
            _repo.AddNewBadge(newb1);
            _repo.AddNewBadge(newb2);
        }
      
        [TestMethod]
        public void ShowAllBadges_ShouldReturnTrue()
        {

            Dictionary<int, Badges> actualReturn = _repo.ShowAllBadges();

            Assert.AreEqual(2, actualReturn.Count);
        }
        [TestMethod] //This also tests GetBadgeByID
        public void AddDoors_ShouldReturnTrue()
        {
            string newDoor = "A3";
            _repo.AddDoors (1234, newDoor);

            Badges target = _repo.GetBadgeByID(1234);

            Assert.IsTrue(target.DoorNames.Contains("A3"));
        }
        [TestMethod]
        public void RemoveDoors_ShouldReturnTrue()
        {
            Badges target = _repo.GetBadgeByID(1234);

            _repo.RemoveDoors(1234, "A2");

            Assert.IsFalse(target.DoorNames.Contains("A2"));
        }
    }
}
