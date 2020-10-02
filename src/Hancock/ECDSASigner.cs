using System.Security.Cryptography;
using Hancock.Helpers;

namespace Hancock
{
    /// <summary>
    ///     ECDSA hash size
    /// </summary>
    public enum HashSize
    {
        /// <summary>
        ///     SHA-256
        /// </summary>
        SHA256 = 256,

        /// <summary>
        ///     SHA-384
        /// </summary>
        SHA328 = 328,

        /// <summary>
        ///     SHA-512
        /// </summary>
        SHA512 = 512,
    }

    /// <summary>
    ///     Signer that uses ECDSA algorithms
    /// </summary>
    public class ECDSASigner : ISigner
    {
        private readonly HashAlgorithmName algorithmName;
        private bool disposedValue;
        private ECDsa dsa;
        private JWK jwk;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ECDSASigner"/> class.
        /// </summary>
        /// <param name="hashSize">Hash size of the curve</param>
        public ECDSASigner(HashSize hashSize)
        {
            switch (hashSize)
            {
                case HashSize.SHA256:
                    algorithmName = HashAlgorithmName.SHA256;
                    Curve = ECCurve.NamedCurves.nistP256;
                    CurveName = "P-256";
                    JWSAlgorithm = "ES256";
                    break;
                case HashSize.SHA328:
                    algorithmName = HashAlgorithmName.SHA384;
                    Curve = ECCurve.NamedCurves.nistP384;
                    CurveName = "P-384";
                    JWSAlgorithm = "ES384";
                    break;
                case HashSize.SHA512:
                    algorithmName = HashAlgorithmName.SHA512;
                    Curve = ECCurve.NamedCurves.nistP521;
                    CurveName = "P-521";
                    JWSAlgorithm = "ES512";
                    break;
            }

            dsa = ECDsa.Create(Curve);
        }

        /// <summary>
        ///     Gets or sets the curve
        /// </summary>
        public ECCurve Curve { get; set; }

        /// <summary>
        ///     Gets or sets the curve name
        /// </summary>
        public string CurveName { get; set; }

        /// <summary>
        ///     Gets or sets the JWS algorithm
        /// </summary>
        public string JWSAlgorithm { get; set; }

        /// <summary>
        ///     Gets the JWK
        /// </summary>
        public JWK JWK
        {
            get
            {
                if (jwk is null)
                {
                    var keyParams = dsa.ExportParameters(false);
                    jwk = new JWK
                    {
                        KeyType = "EC",
                        CurveName = CurveName,
                        X = Base64Helper.SafeEncode(keyParams.Q.X),
                        Y = Base64Helper.SafeEncode(keyParams.Q.Y),
                    };
                }

                return jwk;
            }
        }

        /// <inheritdoc/>
        public byte[] Sign(byte[] data)
        {
            return dsa.SignData(data, algorithmName);
        }

        /// <inheritdoc/>
        public bool Verify(byte[] data, byte[] signature)
        {
            return dsa.VerifyData(data, signature, algorithmName);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dsa.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                dsa = null;
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ECDSASigner()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }
    }
}
