using OTPValidation.Core.Shared.Infrastructure.CrossCutting.NotificationError;

namespace OTPValidation.Core.Shared.Infrastructure.Crosscuting.UseCase
{
    public interface IUseCaseValidation<T>
    {
        NotificationErrors Validate(T request);
    }
}
