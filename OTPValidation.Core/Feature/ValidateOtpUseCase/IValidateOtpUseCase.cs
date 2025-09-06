using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Infrastructure.Crosscuting.UseCase;

namespace OTPValidation.Core.Feature.ValidateOtpUseCase
{
    public interface IValidateOtpUseCase : IUseCase<ValidateOtpRequest>
    {
    }
}
