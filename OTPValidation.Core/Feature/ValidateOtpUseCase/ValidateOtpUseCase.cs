using Microsoft.Extensions.DependencyInjection;
using OTPValidation.Core.Feature.ValidateOtpUseCase.Validation;
using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Domain.Services;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;

namespace OTPValidation.Core.Feature.ValidateOtpUseCase
{
    public sealed class ValidateOtpUseCase(IServiceProvider _serviceProvider) : IValidateOtpUseCase
    {
        public async Task<IOperation> Exec(ValidateOtpRequest request, CancellationToken cancellationToken)
        {
            var notifcation = _serviceProvider.GetRequiredService<IValidateOtpValidationUseCase>()
                                              .Validate(request);
            if (notifcation.HaveError())
                throw new Exception("Request inválida");

            return await _serviceProvider.GetRequiredService<IOtpService>()
                                               .ValidateOtp(request);
        }
    }
}
