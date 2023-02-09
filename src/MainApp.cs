using Dioscuri.Core;

namespace Dioscuri
{
    public class MainApp
    {
        protected readonly IClient _client;

        public MainApp(IClient client)
        {
            _client = client;
        }

        public void Run()
        {
            _client.Start();
        }
    }
}