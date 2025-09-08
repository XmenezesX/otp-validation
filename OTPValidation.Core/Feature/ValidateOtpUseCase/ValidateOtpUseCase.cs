using Microsoft.Extensions.DependencyInjection;
using OTPValidation.Core.Feature.ValidateOtpUseCase.Validation;
using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Domain.Services;

namespace OTPValidation.Core.Feature.ValidateOtpUseCase
{
    //public sealed class ValidateOtpUseCase(IServiceProvider _serviceProvider) : IValidateOtpUseCase
    //{
    //    public byte[] Exec(ValidateOtpRequest request, CancellationToken cancellationToken)
    //    {
    //        var notifcation = _serviceProvider.GetRequiredService<IValidateOtpValidationUseCase>()
    //                                          .Validate(request);
    //        if (notifcation.HaveError())
    //            throw new Exception("Request inválida");
            
    //        var result = _serviceProvider.GetRequiredService<IOtpService>()
    //                                     .ValidateOtp(request);
    //        throw new NotImplementedException();
    //    }
    //}
}
