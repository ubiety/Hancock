﻿namespace Hancock
{
    /// <summary>
    ///     HMAC JWS signer
    /// </summary>
    public class HMACSigner : ISigner
    {
        private bool _disposedValue;

        /// <inheritdoc/>
        public JWK JWK => throw new System.NotImplementedException();

        /// <inheritdoc/>
        public string JWSAlgorithm => throw new System.NotImplementedException();

        /// <inheritdoc/>
        public byte[] Sign(byte[] data)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Verify(byte[] data, byte[] signature)
        {
            throw new System.NotImplementedException();
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
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
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
