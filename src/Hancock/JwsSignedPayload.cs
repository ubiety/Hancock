namespace Hancock {
    public class JwsSignedPayload {
        public object Header { get; init; }

        public string Protected { get; init; }

        public string Payload { get; init; }

        public string Signature { get; init; }
    }
}