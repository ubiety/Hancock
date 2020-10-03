using System;
using System.Security.Cryptography;
using Hancock.Helpers;

namespace Hancock
{
    /// <summary>
    ///     RSA JWK signer
    /// </summary>
    public class RSASigner : ISigner
    {
        private HashAlgorithm _hashAlgorithm;
        private RSACryptoServiceProvider _rsa;
        private bool _disposedValue;
        private JWK _jwk;
        private int _keySize = 2048;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RSASigner"/> class
        /// </summary>
        /// <param name="hashSize">Hash size of the key</param>
        public RSASigner(HashSize hashSize)
        {
            switch (hashSize)
            {
                case HashSize.SHA256:
                    _hashAlgorithm = SHA256.Create();
                    JWSAlgorithm = "RS256";
                    break;
                case HashSize.SHA384:
                    _hashAlgorithm = SHA384.Create();
                    JWSAlgorithm = "RS384";
                    break;
                case HashSize.SHA512:
                    _hashAlgorithm = SHA512.Create();
                    JWSAlgorithm = "RS512";
                    break;
            }

            _rsa = new RSACryptoServiceProvider(KeySize);
        }

        /// <summary>
        ///     Gets or sets the key size
        /// </summary>
        public int KeySize
        {
            get => _keySize;
            set
            {
                if (value < 2048 || value > 4096)
                {
                    throw new ArgumentOutOfRangeException(nameof(KeySize));
                }

                _keySize = value;
            }
        }

        /// <summary>
        ///     Gets the JWS algorithm
        /// </summary>
        public string JWSAlgorithm { get; }

        /// <summary>
        ///     Gets or sets the JSON Web Key
        /// </summary>
        public JWK JWK
        {
            get
            {
                if (_jwk is null)
                {
                    var keyParams = _rsa.ExportParameters(false);
                    _jwk = new JWK
                    {
                        Modulus = Base64Helper.SafeEncode(keyParams.Modulus),
                        Exponent = Base64Helper.SafeEncode(keyParams.Exponent),
                        KeyType = "RSA",
                    };
                }

                return _jwk;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(JWK));
                }

                var keyParams = new RSAParameters
                {
                    Modulus = Base64Helper.SafeDecode(value.Modulus),
                    Exponent = Base64Helper.SafeDecode(value.Exponent),
                    D = Base64Helper.SafeDecode(value.D),
                    DP = Base64Helper.SafeDecode(value.DP),
                    DQ = Base64Helper.SafeDecode(value.DQ),
                    P = Base64Helper.SafeDecode(value.P),
                    InverseQ = Base64Helper.SafeDecode(value.InverseQ),
                    Q = Base64Helper.SafeDecode(value.Q),
                };

                _rsa.ImportParameters(keyParams);
                _jwk = value;
            }
        }

        /// <inheritdoc/>
        public byte[] Sign(byte[] data)
        {
            return _rsa.SignData(data, _hashAlgorithm);
        }

        /// <inheritdoc/>
        public bool Verify(byte[] data, byte[] signature)
        {
            return _rsa.VerifyData(data, _hashAlgorithm, signature);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _rsa.Dispose();
                    _hashAlgorithm.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _rsa = null;
                _hashAlgorithm = null;
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RSASigner()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }
    }
}
