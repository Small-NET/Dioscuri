namespace Dioscuri.Core
{
    public class Parser : IParser
    {
        public Uri ParseUrl(string url)
        {
            var protocolSpecifier = url;

            if (!url.Contains("gemini://"))
            {
                protocolSpecifier = "gemini://" + url;
            }

            var uri = new Uri(protocolSpecifier);

            return uri;
        }
    }
}
