
namespace Dioscuri.Core
{
    // Modeled after https://github.com/InvisibleUp/twinpeaks/tree/master/TwinPeaks/Protocols
    public interface IResponse
    {
        List<byte> bytes { get; }
        string mime { get; }
        Uri uri { get; }
        string encoding { get; }
    }
}
