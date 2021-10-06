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


        [TestInitialize]
        public void Arrange()
        {
            _repo = new Badges_Repo();

            _repo.AddNewBadge(123, _doorListOne);
            _repo.AddNewBadge(456, _doorListTwo);
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
