using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Infrastructure.Crosscuting.UseCase;

namespace OTPValidation.Core.Feature.ValidateOtpUseCase.Validation
{
    public interface IValidateOtpValidationUseCase : IUseCaseValidation<ValidateOtpRequest>
    {
    }
}
