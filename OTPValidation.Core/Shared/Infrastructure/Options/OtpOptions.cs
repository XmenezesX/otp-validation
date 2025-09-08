namespace OTPValidation.Core.Shared.Infrastructure.Options
{
    public sealed class OtpOptions
    {
        public const string SectionName = "OTP:Validation";
        public int PeriodValidateInSeconds { get; set; }
        public int NumberOfDigits { get; set; }
    }
}
