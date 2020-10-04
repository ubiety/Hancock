using System;

namespace Hancock
{
    /// <summary>
    ///     Interface for JWK signing algorithms
    /// </summary>
    public interface ISigner : IDisposable
    {
        /// <summary>
        ///     Gets or sets the JSON Web Key
        /// </summary>
        public JWK JWK { get; set; }

        /// <summary>
        ///     Gets the JSON Web Signature algorithm
        /// </summary>
        public string JWSAlgorithm { get; }

        /// <summary>
        ///     Sign a payload
        /// </summary>
        /// <param name="data">Payload to sign</param>
        /// <returns>Signed payload</returns>
        byte[] Sign(byte[] data);

        /// <summary>
        ///     Verify a signature
        /// </summary>
        /// <param name="data">Data to verify</param>
        /// <param name="signature">Signature to verify</param>
        /// <returns>Value indicating whether the signature is valid or not</returns>
        bool Verify(byte[] data, byte[] signature);
    }
}
