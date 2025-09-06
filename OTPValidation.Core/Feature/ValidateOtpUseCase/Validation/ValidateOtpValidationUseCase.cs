using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.NotificationError;

namespace OTPValidation.Core.Feature.ValidateOtpUseCase.Validation
{
    public sealed class ValidateOtpValidationUseCase : IValidateOtpValidationUseCase
    {
        public NotificationErrors Validate(ValidateOtpRequest request)
        {
            var notificationErrors = NotificationErrors.Empty;
            if (string.IsNullOrWhiteSpace(request.Code))
                notificationErrors.AddError(nameof(request.Code), "O código é obrigatório");

            return notificationErrors;
        }
    }
}
