using Claims_Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Claims_Tests
{
    [TestClass]
    public class Claims_Tests
    {
        [TestMethod]
        public void AddClaim_ShouldReturnNotNull()
        {
            Claims claim = new Claims();
            Claims claim1 = new Claims();
            Claims_Repo repo = new Claims_Repo();

            repo.AddClaim(claim);
            repo.AddClaim(claim1);

            Queue<Claims> actualReturn = repo.ShowAllClaims();

            Assert.AreEqual(2, actualReturn.Count);
        }
       
        [TestMethod]
        public void NextClaim_ShouldReturnTrue()
        {
            Claims claim = new Claims();
            Claims claim1 = new Claims();
            Claims_Repo repo = new Claims_Repo();

            repo.AddClaim(claim);
            repo.AddClaim(claim1);

            Claims claim0 = repo.GetNextClaim();

            Assert.AreEqual(claim, claim0);
        }
    }
}
