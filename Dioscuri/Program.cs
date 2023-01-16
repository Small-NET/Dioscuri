using Dioscuri.Core;

namespace Dioscuri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cert = Certificates.CreateX509Certificate2("dioscuri.browser");

            IBrowserEngine browserEngine = new BrowserEngine(cert);

            var client = new Client(browserEngine);

            client.StartClient();
        }
    }
}