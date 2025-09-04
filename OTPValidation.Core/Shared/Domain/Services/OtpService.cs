using Microsoft.Extensions.DependencyInjection;
using OTPValidation.Core.Shared.Domain.Authenticator;
using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Domain.Services.QrCodeGenerator;

namespace OTPValidation.Core.Shared.Domain.Services
{
    public sealed class OtpService(IServiceProvider _serviceProvider) : IOtpService
    {
        public byte[] CreateOtp(CreateOtpRequest request)
        {
            var (secretBase32, otpUrl) = _serviceProvider.GetRequiredService<IAuthenticatorService>()
                                                         .Create(request.Email);

            var qrCode = _serviceProvider.GetRequiredService<IQrCodeGeneratorService>()
                                         .Generate(otpUrl);

            return qrCode;
        }
    }
}
