using Microsoft.Extensions.DependencyInjection;
using OTPValidation.Core.Feature.CreateOtpUseCase.CreateOtpValidation;
using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Domain.Services;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;

namespace OTPValidation.Core.Feature.CreateOtpUseCase
{
    public sealed class CreateOtpUseCase(IServiceProvider _serviceProvider) : ICreateOtpUseCase
    {
        public async Task<IOperation> Exec(CreateOtpRequest request, CancellationToken cancellationToken)
        {
            var notificationErrors = _serviceProvider.GetRequiredService<ICreateOtpValidationUseCase>()
                                                     .Validate(request);
            if (notificationErrors.HaveError())
                throw new Exception("Request Inválida");

            return await _serviceProvider.GetRequiredService<IOtpService>()
                                         .CreateOtpAsync(request);
        }
    }
}
