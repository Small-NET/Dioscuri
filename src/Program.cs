using Dioscuri.Core;

namespace Dioscuri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cert = Certificates.CreateX509Certificate2("dioscuri.browser");

            IParser parser = new Parser();
            IBrowserEngine browserEngine = new BrowserEngine(cert, parser);

            var client = new Client(browserEngine);

            client.StartClient();
        }
    }
}