using System;
using System.Security.Cryptography;
using Hancock.Helpers;

namespace Hancock
{
    /// <summary>
    ///     HMAC JWS signer
    /// </summary>
    public class HMACSigner : ISigner
    {
        private bool _disposedValue;
        private byte[] _key;
        private HMAC _hmac;
        private JWK _jwk;

        /// <summary>
        ///     Initializes a new instance of the <see cref="HMACSigner"/> class
        /// </summary>
        /// <param name="hashSize">Hash size to use</param>
        /// <param name="jwk">JSON Web Key to use for signature</param>
        public HMACSigner(HashSize hashSize, JWK jwk)
        {
            JWK = jwk;

            switch (hashSize)
            {
                case HashSize.SHA256:
                    _hmac = new HMACSHA256(_key);
                    JWSAlgorithm = "HS256";
                    break;
                case HashSize.SHA384:
                    _hmac = new HMACSHA384(_key);
                    JWSAlgorithm = "HS384";
                    break;
                case HashSize.SHA512:
                    _hmac = new HMACSHA512(_key);
                    JWSAlgorithm = "HS512";
                    break;
            }
        }

        /// <inheritdoc/>
        public JWK JWK
        {
            get
            {
                return _jwk ??= new JWK
                    {
                        KeyType = "oct",
                        Key = Base64Helper.SafeEncode(_key),
                    };
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(JWK));
                }

                _key = Base64Helper.SafeDecode(value.Key);
                _jwk = value;
            }
        }

        /// <inheritdoc/>
        public string JWSAlgorithm { get; }

        /// <inheritdoc/>
        public byte[] Sign(byte[] data)
        {
            return _hmac.ComputeHash(data);
        }

        /// <inheritdoc/>
        public bool Verify(byte[] data, byte[] signature)
        {
            var expected = Sign(data);

            return Equals(signature, expected);
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
                    _hmac.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                _hmac = null;
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~HMACSigner()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }
    }
}
