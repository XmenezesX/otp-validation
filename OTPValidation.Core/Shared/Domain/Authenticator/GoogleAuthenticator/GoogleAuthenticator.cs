using OtpNet;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;

namespace OTPValidation.Core.Shared.Domain.Authenticator.GoogleAuthenticator
{
    public sealed class GoogleAuthenticator : IGoogleAuthenticator
    {

        public (string base32Secret, string otpUrl) Create(string email)
        {
            var secretKey = KeyGeneration.GenerateRandomKey(20);
            var secretBase32 = Base32Encoding.ToString(secretKey);
            var otpAuthUrl = $"otpauth://totp/OtpValidation:{email}?secret={secretBase32}&issuer=OtpValidation&digits=6";
            return (secretBase32, otpAuthUrl);
        }
        public Task<IOperation> Validate(string value)
        {
            throw new NotImplementedException();
        }
    }
}
