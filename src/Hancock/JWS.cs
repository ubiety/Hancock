using System.Text;
using System.Text.Json;
using Hancock.Helpers;

namespace Hancock
{
    /// <summary>
    ///     JSON Web Signature
    /// </summary>
    public class JWS
    {
        /// <summary>
        ///     Gets the JWS signer, either ECDSA or RSA
        /// </summary>
        public ISigner Signer { get; init; }

        /// <summary>
        ///     Sign a JSON payload
        /// </summary>
        /// <param name="header">JSON Web Signature header</param>
        /// <param name="payload">Data payload to sign</param>
        /// <returns><see cref="JwsSignedPayload"/> containing the data and signature</returns>
        public JwsSignedPayload SignPayload(JwsHeader header, string payload)
        {
            var protectedHeader = Base64Helper.SafeEncode(JsonSerializer.Serialize(header));
            var encodedPayload = Base64Helper.SafeEncode(JsonSerializer.Serialize(payload));

            var signingInput = Encoding.ASCII.GetBytes($"{protectedHeader}.{encodedPayload}");

            var signature = Base64Helper.SafeEncode(Signer.Sign(signingInput));

            return new JwsSignedPayload
            {
                Payload = encodedPayload,
                Protected = protectedHeader,
                Signature = signature,
                Header = header,
            };
        }
    }
}
