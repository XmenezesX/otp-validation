using OTPValidation.Core.Shared.Domain.Request;

namespace OTPValidation.Core.Shared.Domain.Services
{
    public interface IOtpService
    {
        byte[] CreateOtp(CreateOtpRequest request);
        bool ValidateOtp(ValidateOtpRequest request);
    }
}
