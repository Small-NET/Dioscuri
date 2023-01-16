using System;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using SmolNetSharp.Protocols;

namespace Dioscuri.Core
{
    public class BrowserEngine : IBrowserEngine
    {
        private readonly X509Certificate2 _certificate;
        private readonly IParser _parser;

        public BrowserEngine(X509Certificate2 certificate, IParser parser)
        {
            _certificate = certificate;
            _parser = parser;
        }

        public string DownloadContent(string url)
        {
            if (string.IsNullOrEmpty(url)) 
            {
                return "Error: please input a URL";
            }

            var uri = _parser.ParseUrl(url);

            return HandleDownload(uri);
        }

        private string HandleDownload(Uri uri)
        {
            // This needs to be true otherwise an exception is thrown 
            // Refer to https://github.com/markjamesm/Dioscuri/issues/1
            var connectInsecure = true;

            var geminiResponse = new GeminiResponse();

            try
            {
                geminiResponse = (GeminiResponse)Gemini.Fetch(uri, _certificate, "", connectInsecure);
            }

            catch (Exception ex)
            {
                return $"Error, could not fetch page. Details:\n\n {ex.Message}";
            }

            var responseArray = geminiResponse.bytes.ToArray();
            var pageContent = System.Text.Encoding.UTF8.GetString(responseArray);

            return pageContent;
        }
    }
}
