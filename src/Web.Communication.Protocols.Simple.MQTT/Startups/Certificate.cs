﻿using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Web.Communication.Protocols.Simple.MQTT.Startups
{
    internal static class Certificate
    {
        public static X509Certificate2 CreateSelfSignedCertificate(string oid)
        {
            var sanBuilder = new SubjectAlternativeNameBuilder();
            sanBuilder.AddIpAddress(IPAddress.Loopback);
            sanBuilder.AddIpAddress(IPAddress.IPv6Loopback);
            sanBuilder.AddDnsName("localhost");

            using (var rsa = RSA.Create())
            {
                var certRequest = new CertificateRequest("CN=localhost", rsa, HashAlgorithmName.SHA512, RSASignaturePadding.Pkcs1);

                certRequest.CertificateExtensions.Add(
                    new X509KeyUsageExtension(X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.DigitalSignature, false));

                certRequest.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(new OidCollection { new(oid) }, false));

                certRequest.CertificateExtensions.Add(sanBuilder.Build());

                using (var certificate = certRequest.CreateSelfSigned(DateTimeOffset.Now.AddMinutes(-10), DateTimeOffset.Now.AddMinutes(10)))
                {
                    var pfxCertificate = new X509Certificate2(
                        certificate.Export(X509ContentType.Pfx),
                        (string)null!,
                        X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);

                    return pfxCertificate;
                }
            }
        }
    }
}
