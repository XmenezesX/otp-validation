using System.Text.Json.Serialization;

namespace OTPValidation.Core.Shared.Domain.Request
{
    public sealed record ValidateOtpRequest
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("validationId")]
        public Guid ValidationId { get; set; }
    }
}
