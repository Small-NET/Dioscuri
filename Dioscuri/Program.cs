using Dioscuri.Core;

namespace Dioscuri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cert = Certificates.CreateX509Certificate2("Dioscuri Browser");
            var browserEngine = new BrowserEngine(cert);
            var client = new Client(browserEngine);

            client.StartClient();
        }
    }
}