using System.Text.Json.Serialization;

namespace OTPValidation.Core.Shared.Domain.Request
{
    public sealed record ValidateOtpRequest
    {
        [JsonPropertyName("code")]
        public string Code { get; init; }

        [JsonPropertyName("otpId")]
        public Guid OtpId { get; init; }
    }
}
