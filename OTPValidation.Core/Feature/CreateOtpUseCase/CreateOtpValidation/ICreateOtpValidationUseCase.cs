using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Infrastructure.Crosscuting.UseCase;

namespace OTPValidation.Core.Feature.CreateOtpUseCase.CreateOtpValidation
{
    public interface ICreateOtpValidationUseCase: IUseCaseValidation<CreateOtpRequest>
    {
    }
}
