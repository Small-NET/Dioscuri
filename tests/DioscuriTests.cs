using Dioscuri.Core;

namespace DioscuriTests
{
    [TestClass]
    public class DioscuriTests
    {
        [TestMethod]
        public void TestRetrieveResponseFromUrl()
        {
            // Arrange
            var certificate = Certificates.CreateX509Certificate2("Test");
            var parser = new Parser();
            var browserEngine = new BrowserEngine(certificate, parser);

            // Act
            var response = browserEngine.DownloadContent(string.Empty);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(response));
        }
    }
}