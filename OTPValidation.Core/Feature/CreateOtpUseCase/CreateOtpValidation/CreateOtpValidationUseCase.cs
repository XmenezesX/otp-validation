using OTPValidation.Core.Shared.Domain.Enums;
using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Infrastructure.Crosscuting.Utils;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.NotificationError;

namespace OTPValidation.Core.Feature.CreateOtpUseCase.CreateOtpValidation
{
    public sealed class CreateOtpValidationUseCase : ICreateOtpValidationUseCase
    {
        public NotificationErrors Validate(CreateOtpRequest request)
        {
            var notificationErros = NotificationErrors.Empty;
            if (request is null)
                return notificationErros.AddError(nameof(request), "A request é nula");

            if (!request.Email.IsValidEmail())
                notificationErros.AddError(nameof(request.Email), "O email é inválido");

            if (request.Authenticator == Authenticators.None)
                notificationErros.AddError(nameof(request.Authenticator), "O authenticator é inválido");

            return notificationErros;
        }
    }
}
