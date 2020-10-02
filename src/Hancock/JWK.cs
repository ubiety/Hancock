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
    }
}
