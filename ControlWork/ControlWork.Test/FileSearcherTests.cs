using System;
using System.IO;
using ControlWork.StrFinderConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControlWork.Test
{
    [TestClass]
    public class FileSearcherTests
    {
        [TestMethod]
        public void TryCreate_CorrectInput_TrueAndNotNullObject()
        {
            //Arrange
            //Act
            var target = FileSearcher.TryCreate("C:\\testFiles\\somefile.txt", "test",out var fileSearcher);
            //Assert
            Assert.IsTrue(target);
            Assert.IsNotNull(fileSearcher);
        }
        [TestMethod]
        public void TryCreate_InCorrectInput_FalseAndNullObject() {
            //Arrange
            //Act
            var target = FileSearcher.TryCreate("C:\\notExistDirectory\\notexistsomefile.txt", "test", out var fileSearcher);
            //Assert
            Assert.IsFalse(target);
            Assert.IsNull(fileSearcher);
        }
    }
}
