using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Domain.Response;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;

namespace OTPValidation.Core.Shared.Domain.Services
{
    public interface IOtpService
    {
        Task<IOperation<CreateOtpResponse>> CreateOtpAsync(CreateOtpRequest request);
        bool ValidateOtp(ValidateOtpRequest request);
    }
}
