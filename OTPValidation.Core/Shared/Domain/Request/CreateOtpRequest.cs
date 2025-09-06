using System.Text.Json.Serialization;

namespace OTPValidation.Core.Shared.Domain.Request
{
    public sealed record CreateOtpRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; init; }

        [JsonPropertyName("password")]
        public string Password { get; init; }
    }
}
