using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebTests
{
    [TestClass]
    public class WebTests
    {
        [TestMethod]
        public void ConvertStringToStream_EmptyStringReturnsNullStream_Test()
        {
            //Arrange
            var web = new Web.Web();
            var text = string.Empty;

            //Act
            web.ConvertStringToStream(text);

            //Assert
            Assert.AreEqual(null, web.Stream);
        }

        [TestMethod]
        public void ConvertStringToStream_StringNotEmptyReturnsStream_Test()
        {
            //Arrange
            var web = new Web.Web();
            var testText = "Test text";

            //Act
            web.ConvertStringToStream(testText);

            //Assert
            Assert.AreNotEqual(null, web.Stream);
        }

        [TestMethod]
        public void RequestUrl_EmptyString_Test()
        {
            //Arrange
            var web = new Web.Web();
            var testUrl = string.Empty;

            //Act
            web.RequestUrl(testUrl);

            //Assert
            Assert.AreEqual(null, web.Response);
        }

        [TestMethod]
        public void RequestUrl_InvalidUrl_Test()
        {
            //Arrange
            var web = new Web.Web();
            var testUrl = "Invalid Url";

            //Act
            web.RequestUrl(testUrl);

            //Assert
            Assert.AreEqual(string.Empty, web.Response);
        }

        [TestMethod]
        public void RequestUrl_ValidUrl_Test()
        {
            //Arrange
            var web = new Web.Web();
            var testUrl = "https://www.google.com.au";

            //Act
            web.RequestUrl(testUrl);

            //Assert
            Assert.AreNotEqual(string.Empty, web.Response);
        }
    }
}
