using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Dioscuri.Core
{
    public class Certificates
    {
        public static X509Certificate2 CreateX509Certificate2(string certName)
        {
            var ecdsa = ECDsa.Create();
            var rsa = RSA.Create();
            var req = new CertificateRequest($"cn={certName}", rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            var cert = req.CreateSelfSigned(DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1));

            return new X509Certificate2(cert.Export(X509ContentType.Pfx, "password"), "password");
        }
    }
}
