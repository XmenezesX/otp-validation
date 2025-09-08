using System.Text.Json.Serialization;

namespace OTPValidation.Core.Shared.Domain.Response
{
    public sealed record CreateOtpResponse
    {
        [JsonPropertyName("validationId")]
        public Guid ValidationId { get; init; }

        [JsonPropertyName("otpUri")]
        public string OtpUri { get; init; }
    }
}
