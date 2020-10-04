using System.Security.Cryptography;
using Hancock.Helpers;

namespace Hancock
{
    /// <summary>
    ///     Signer that uses ECDSA algorithms
    /// </summary>
    public class ECDSASigner : ISigner
    {
        private readonly HashAlgorithmName _algorithmName;
        private bool _disposedValue;
        private ECDsa _dsa;
        private JWK _jwk;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ECDSASigner"/> class.
        /// </summary>
        /// <param name="hashSize">Hash size of the curve</param>
        public ECDSASigner(HashSize hashSize)
        {
            switch (hashSize)
            {
                case HashSize.SHA256:
                    _algorithmName = HashAlgorithmName.SHA256;
                    Curve = ECCurve.NamedCurves.nistP256;
                    CurveName = "P-256";
                    JWSAlgorithm = "ES256";
                    break;
                case HashSize.SHA384:
                    _algorithmName = HashAlgorithmName.SHA384;
                    Curve = ECCurve.NamedCurves.nistP384;
                    CurveName = "P-384";
                    JWSAlgorithm = "ES384";
                    break;
                case HashSize.SHA512:
                    _algorithmName = HashAlgorithmName.SHA512;
                    Curve = ECCurve.NamedCurves.nistP521;
                    CurveName = "P-521";
                    JWSAlgorithm = "ES512";
                    break;
            }

            _dsa = ECDsa.Create(Curve);
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
        ///     Gets the JWS algorithm
        /// </summary>
        public string JWSAlgorithm { get; }

        /// <summary>
        ///     Gets the JWK
        /// </summary>
        public JWK JWK
        {
            get
            {
                if (_jwk is null)
                {
                    var keyParams = _dsa.ExportParameters(false);
                    _jwk = new JWK
                    {
                        KeyType = "EC",
                        CurveName = CurveName,
                        X = Base64Helper.SafeEncode(keyParams.Q.X),
                        Y = Base64Helper.SafeEncode(keyParams.Q.Y),
                    };
                }

                return _jwk;
            }
        }

        /// <inheritdoc/>
        public byte[] Sign(byte[] data)
        {
            return _dsa.SignData(data, _algorithmName);
        }

        /// <inheritdoc/>
        public bool Verify(byte[] data, byte[] signature)
        {
            return _dsa.VerifyData(data, signature, _algorithmName);
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
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _dsa.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                _dsa = null;
                _disposedValue = true;
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
