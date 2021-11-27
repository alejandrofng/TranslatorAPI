using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.UnitTests
{
    [TestClass]
    public class LanguageTests
    {
        [TestMethod]
        public void CreateLanguage()
        {
            Guid Id = Guid.NewGuid();
            string Code = "es-es";
            Guid PriceAlteratorId = Guid.NewGuid();

            Language Language = new(Id, Code, PriceAlteratorId);
            Assert.AreEqual(Language.Id, Id);
            Assert.AreEqual(Language.Code, Code);
            Assert.AreEqual(Language.PriceAlteratorId, PriceAlteratorId);
        }
        [TestMethod]
        public void PriceAlteratorIsNullable()
        {
            Guid Id = Guid.NewGuid();
            string Code = "es-es";
            Language Language = new(Id, Code, null);
            Assert.AreEqual(Language.PriceAlteratorId, null);
        }
    }
}
