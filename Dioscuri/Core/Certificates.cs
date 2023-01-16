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


            var random = new Random();

            // Randomly generate the certificate password
            var certificatePassword = GenerateX509CertificatePassword();

            return new X509Certificate2(cert.Export(X509ContentType.Pfx, certificatePassword), certificatePassword);
        }

        private static string GenerateX509CertificatePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789$#!";
            var length = 7;

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());

            return randomString;
        }
    }
}
