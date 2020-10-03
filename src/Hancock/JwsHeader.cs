using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hancock
{
    /// <summary>
    ///     JWS Header
    /// </summary>
    public class JwsHeader
    {
        /// <summary>
        ///     Gets or sets the algorithm parameter
        /// </summary>
        [JsonPropertyName("alg")]
        public string Algorithm { get; set; }

        /// <summary>
        ///     Gets or sets the JWK set URL
        /// </summary>
        [JsonPropertyName("jku")]
        public Uri JWKSetUrl { get; set; }

        /// <summary>
        ///     Gets or sets the JSON web key
        /// </summary>
        [JsonPropertyName("jwk")]
        public JWK JWK { get; set; }

        /// <summary>
        ///     Gets or sets the key id
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
        ///     Gets or sets the type paramater
        /// </summary>
        [JsonPropertyName("typ")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the content type parameter
        /// </summary>
        [JsonPropertyName("cty")]
        public string ContentType { get; set; }

        /// <summary>
        ///     Gets the critical parameter
        /// </summary>
        [JsonPropertyName("crit")]
        public List<string> Critical { get; }

        /// <summary>
        ///     Gets or sets the JWS request url
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        ///     Gets or sets the JWS nonce
        /// </summary>
        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }
    }
}
