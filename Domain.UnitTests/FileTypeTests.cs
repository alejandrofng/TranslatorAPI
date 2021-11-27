using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.UnitTests
{
    [TestClass]
    public class FileTypeTests
    {
        [TestMethod]
        public void CreateFileType()
        {
            Guid Id = Guid.NewGuid();
            string Code = "txt";
            Guid PriceAlteratorId = Guid.NewGuid();

            FileType FileType = new(Id, Code, PriceAlteratorId);
            Assert.AreEqual(FileType.Id, Id);
            Assert.AreEqual(FileType.Code, Code);
            Assert.AreEqual(FileType.PriceAlteratorId, PriceAlteratorId);
        }
        [TestMethod]
        public void PriceAlteratorIsNullable()
        {
            Guid Id = Guid.NewGuid();
            string Code = "txt";
            FileType FileType = new(Id, Code, null);
            Assert.AreEqual(FileType.PriceAlteratorId, null);
        }
    }
}
