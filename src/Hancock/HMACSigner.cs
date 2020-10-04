namespace Hancock
{
    /// <summary>
    ///     HMAC JWS signer
    /// </summary>
    public class HMACSigner : ISigner
    {
        private bool disposedValue;

        public JWK JWK => throw new System.NotImplementedException();

        public string JWSAlgorithm => throw new System.NotImplementedException();

        public byte[] Sign(byte[] data)
        {
            throw new System.NotImplementedException();
        }

        public bool Verify(byte[] data, byte[] signature)
        {
            throw new System.NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~HMACSigner()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }
    }
}
