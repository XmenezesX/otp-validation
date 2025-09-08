using System.Text.Json.Serialization;

namespace OTPValidation.Core.Shared.Domain.Response
{
    public sealed record ValidationOtpResponse
    {
        [JsonPropertyName("isValid")]
        public bool IsValid { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; }
    }
}
