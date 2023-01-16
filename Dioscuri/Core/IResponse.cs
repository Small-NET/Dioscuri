
namespace Dioscuri.Core
{
    // Modeled after the Smolnet C# library by LukeEmmet
    // https://github.com/LukeEmmet/SmolNetSharp
    public interface IResponse
    {
        List<byte> bytes { get; }
        string mime { get; }
        Uri uri { get; }
        string encoding { get; }
    }
}
