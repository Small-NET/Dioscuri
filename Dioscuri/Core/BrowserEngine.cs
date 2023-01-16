using System.Security.Cryptography.X509Certificates;
using SmolNetSharp.Protocols;

namespace Dioscuri.Core
{
    public class BrowserEngine : IBrowserEngine
    {
        private readonly X509Certificate2 _certificate;

        public BrowserEngine(X509Certificate2 certificate)
        {
            _certificate = certificate;
        }

        public string RetrieveResponseFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) 
            {
                return "Error: please input a URL";
            }

            var uri = new Uri(url);

            // This needs to be true otherwise an exception is thrown 
            // Refer to https://github.com/markjamesm/Dioscuri/issues/1
            var connectInsecure = true;

            var geminiResponse = (GeminiResponse)Gemini.Fetch(uri, _certificate, "", connectInsecure);
            var responseArray = geminiResponse.bytes.ToArray();
            var pageContent = System.Text.Encoding.UTF8.GetString(responseArray);

            return pageContent;
        }
    }
}
