using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OtpNet;
using OTPValidation.Core.Shared.Infrastructure.Crosscuting.Utils;
using OTPValidation.Core.Shared.Infrastructure.Options;

namespace OTPValidation.Core.Shared.Domain.Authenticator
{
    public sealed class Authenticator(IServiceProvider _serviceProvider) : IAuthenticator
    {
        public (string secretKey, string otpUri) Create(string email)
        {
            var otpOptions = _serviceProvider.GetRequiredService<IOptions<OtpOptions>>().Value;
            var secretKey = KeyGeneration.GenerateRandomKey(20);
            var secretBase32 = Base32Encoding.ToString(secretKey);
            
            var otpAuthUri = $"otpauth://totp/OtpValidation:{email}?secret={secretBase32}" +
                             $"&issuer=OtpValidation&digits={otpOptions.NumberOfDigits}" +
                             $"&period={otpOptions.PeriodValidateInSeconds}";

            return (secretKey.ToBase64(), otpAuthUri);
        }
        public bool Validate(string code, string secretKey)
        {
            try
            {
                var otpOptions = _serviceProvider.GetRequiredService<IOptions<OtpOptions>>().Value;
                
                var key = Base32Encoding.ToBytes(secretKey);
                var totp = new Totp(key, otpOptions.PeriodValidateInSeconds, OtpHashMode.Sha1, 6);
                return totp.VerifyTotp(code, out _, new VerificationWindow(1, 1));
            }
            catch
            {
                return false;
            }
        }
    }
}
