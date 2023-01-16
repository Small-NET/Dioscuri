using Pluralsight.Crypto;
using System.Security.Cryptography.X509Certificates;

namespace Dioscuri.Core
{
    public class CreateCert
    {
        public static X509Certificate2 GenerateSelfSignedCertificate()
        {
            using var ctx = new CryptContext();

            ctx.Open();

            X509Certificate2 cert = ctx.CreateSelfSignedCertificate(
                new SelfSignedCertProperties
                {
                    IsPrivateKeyExportable = true,
                    KeyBitLength = 4096,
                    Name = new X500DistinguishedName("cn=localhost"),
                    ValidFrom = DateTime.Today.AddDays(-1),
                    ValidTo = DateTime.Today.AddYears(1),
                });

            System.Diagnostics.Debug.WriteLine(cert.ToString());

            return cert;
        }
    }
}
