using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Domain.Entities;

namespace Domain.UnitTests
{
    [TestClass]
    public class PriceAlteratorTests
    {
        [TestMethod]
        public void CreatePriceAlterator()
        {
            Guid Id = Guid.NewGuid();
            bool IsDiscount = false;
            decimal Percentage = 10M;

            PriceAlterator PriceAlterator = new(Id, IsDiscount, Percentage);
            Assert.AreEqual(PriceAlterator.Id, Id);
            Assert.AreEqual(PriceAlterator.IsDiscount, IsDiscount);
            Assert.AreEqual(PriceAlterator.Percentage, Percentage);
        }
    }
}
