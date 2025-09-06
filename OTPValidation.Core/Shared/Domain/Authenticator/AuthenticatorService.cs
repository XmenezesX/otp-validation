using OtpNet;

namespace OTPValidation.Core.Shared.Domain.Authenticator
{
    public sealed class AuthenticatorService : IAuthenticatorService
    {
        private const int PeriodInSeconds = 60; 
        private const int Digits = 6;
        public (string base32Secret, string otpUrl) Create(string email)
        {
            var secretKey = KeyGeneration.GenerateRandomKey(20);
            var secretBase32 = Base32Encoding.ToString(secretKey);
            var otpAuthUrl = $"otpauth://totp/OtpValidation:{email}?secret={secretBase32}&issuer=OtpValidation&digits={Digits}&period={PeriodInSeconds}";

            return (secretBase32, otpAuthUrl);
        }
        public bool Validate(string code, string secretKey)
        {
            try
            {
                var key = Base32Encoding.ToBytes(secretKey);
                var totp = new Totp(key, 60, OtpHashMode.Sha1, 6);
                return totp.VerifyTotp(code, out _, new VerificationWindow(1, 1));
            }
            catch
            {
                return false;
            }
        }
    }
}
