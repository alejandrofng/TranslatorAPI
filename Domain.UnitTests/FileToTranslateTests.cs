using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.UnitTests
{
    [TestClass]
    public class FileToTranslateTests
    {
        [TestMethod]
        public void CreateFileToTranslate()
        {
            Guid Id = Guid.NewGuid();
            Guid ProjectId = Guid.NewGuid();
            string Name = "name";
            string Content = "testContent";
            string Comments = "comments";
            Guid FileTypeId = Guid.NewGuid();

            FileToTranslate FileToTranslate = new(Id, ProjectId, Name, FileTypeId,Content,Comments);
            Assert.AreEqual(FileToTranslate.Id, Id);
            Assert.AreEqual(FileToTranslate.ProjectId, ProjectId);
            Assert.AreEqual(FileToTranslate.Name, Name);
            Assert.AreEqual(FileToTranslate.FileTypeId, FileTypeId);
            Assert.AreEqual(FileToTranslate.Content, Content);
            Assert.AreEqual(FileToTranslate.Comments, Comments);
        }
    }
}
