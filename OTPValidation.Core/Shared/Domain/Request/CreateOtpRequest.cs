using OTPValidation.Core.Shared.Domain.Enums;
using System.Text.Json.Serialization;

namespace OTPValidation.Core.Shared.Domain.Request
{
    public sealed record CreateOtpRequest
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("authenticator")]
        public Authenticators Authenticator { get; set; }
    }
}
