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
            var browserEngine = new BrowserEngine(certificate);

            // Act
            var response = browserEngine.RetrieveResponseFromUrl(string.Empty);

            // Assert
            Assert.IsFalse(string.IsNullOrEmpty(response));
        }
    }
}