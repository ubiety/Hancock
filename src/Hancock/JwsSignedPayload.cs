namespace Hancock
{
    /// <summary>
    ///     Signed JSON payload.
    /// </summary>
    public class JwsSignedPayload
    {
        /// <summary>
        ///     Gets the unprotected JWS header.
        /// </summary>
        public object Header { get; init; }

        /// <summary>
        ///     Gets the protected JWS header.
        /// </summary>
        public string Protected { get; init; }

        /// <summary>
        ///     Gets the JWS payload.
        /// </summary>
        public string Payload { get; init; }

        /// <summary>
        ///     Gets the JWS signature.
        /// </summary>
        public string Signature { get; init; }
    }
}