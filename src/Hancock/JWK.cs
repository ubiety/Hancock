using System;
using System.Text.Json.Serialization;

namespace Hancock
{
    /// <summary>
    ///     JSON Web Key
    /// </summary>
    public class JWK
    {
        /// <summary>
        ///     Gets or sets the JWK key type
        /// </summary>
        [JsonPropertyName("kty")]
        public string KeyType { get; set; }

        /// <summary>
        ///     Gets or sets the public key use parameter
        /// </summary>
        [JsonPropertyName("use")]
        public string Use { get; set; }

        /// <summary>
        ///     Gets or sets the key operations parameter
        /// </summary>
        [JsonPropertyName("key_ops")]
        public string KeyOperations { get; set; }

        /// <summary>
        ///     Gets or sets the JWK alorithm
        /// </summary>
        [JsonPropertyName("alg")]
        public string Algorithm { get; set; }

        /// <summary>
        ///     Gets or sets the key id parameter
        /// </summary>
        [JsonPropertyName("kid")]
        public string KeyId { get; set; }

        /// <summary>
        ///     Gets or sets the X.509 URL parameter
        /// </summary>
        [JsonPropertyName("x5u")]
        public Uri X509Url { get; set; }

        /// <summary>
        ///     Gets or sets the X.509 certificate chain parameter
        /// </summary>
        [JsonPropertyName("x5c")]
        public string X509CertificateChain { get; set; }

        /// <summary>
        ///     Gets or sets the X.509 certificate SHA-1 thumbprint parameter
        /// </summary>
        [JsonPropertyName("x5t")]
        public string X509CertificateSHA1Thumbprint { get; set; }

        /// <summary>
        ///     Gets or sets the X.509 certificate SHA-256 thumbprint parameter
        /// </summary>
        [JsonPropertyName("x5t#S256")]
        public string X509CertificateSHA256Thumbprint { get; set; }

        /// <summary>
        ///     Gets or sets the elliptical curve X coordinate
        /// </summary>
        [JsonPropertyName("x")]
        public string X { get; set; }

        /// <summary>
        ///     Gets or sets the elliptical curve Y coordinate
        /// </summary>
        [JsonPropertyName("y")]
        public string Y { get; set; }

        /// <summary>
        ///     Gets or sets the JWS curve name
        /// </summary>
        [JsonPropertyName("crv")]
        public string CurveName { get; set; }

        /// <summary>
        ///     Gets or sets the RSA encryption modulus
        /// </summary>
        [JsonPropertyName("n")]
        public string Modulus { get; set; }

        /// <summary>
        ///     Gets or sets the RSA encryption exponent
        /// </summary>
        [JsonPropertyName("e")]
        public string Exponent { get; set; }

        /// <summary>
        ///     Gets or sets the RSA private exponent
        /// </summary>
        [JsonPropertyName("d")]
        public string D { get; set; }

        /// <summary>
        ///     Gets or sets the RSA prime 1
        /// </summary>
        [JsonPropertyName("p")]
        public string P { get; set; }

        /// <summary>
        ///     Gets or sets the RSA exponent 1
        /// </summary>
        [JsonPropertyName("dp")]
        public string DP { get; set; }

        /// <summary>
        ///     Gets or sets the RSA exponent 2
        /// </summary>
        [JsonPropertyName("dq")]
        public string DQ { get; set; }

        /// <summary>
        ///     Gets or sets the RSA coefficient
        /// </summary>
        [JsonPropertyName("qi")]
        public string InverseQ { get; set; }

        /// <summary>
        ///     Gets or sets the RSA prime 2
        /// </summary>
        [JsonPropertyName("q")]
        public string Q { get; set; }
    }
}
