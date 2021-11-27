using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.UnitTests
{
    [TestClass]
    public class TranslationBasketTests
    {
        [TestMethod]
        public void AddLanguageToTranslationBasket()
        {
            TranslationBasket TranslationBasket = new(Guid.NewGuid(),Guid.NewGuid(),DateTime.Now);
            Language Language = new(Guid.NewGuid(), "es-es",null);
            TranslationBasket.AddLanguage(Language);
            Assert.IsTrue(TranslationBasket.Languages.Any(l=>l.Language == Language));
        }
        [TestMethod]
        public void CreateTranslationBasket()
        {
            Guid Id = Guid.NewGuid();
            Guid CustomerId = Guid.NewGuid();
            DateTime DueDate = DateTime.Now;

            TranslationBasket TranslationBasket = new(Id, CustomerId, DueDate);
            Assert.AreEqual(TranslationBasket.Id, Id);
            Assert.AreEqual(TranslationBasket.CustomerId, CustomerId);
            Assert.AreEqual(TranslationBasket.DueDate, DueDate);
        }
    }
}
