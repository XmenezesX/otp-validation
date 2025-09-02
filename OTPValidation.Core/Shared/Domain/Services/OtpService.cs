using Microsoft.Extensions.DependencyInjection;
using OTPValidation.Core.Shared.Domain.Authenticator;
using OTPValidation.Core.Shared.Domain.Authenticator.GoogleAuthenticator;
using OTPValidation.Core.Shared.Domain.Enums;
using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;

namespace OTPValidation.Core.Shared.Domain.Services
{
    public sealed class OtpService(IServiceProvider _serviceProvider) : IOtpService
    {
        public Task<IOperation> CreateOtpAsync(CreateOtpRequest request)
        {
            IAuthenticator authenticator = request.Authenticator switch
            {
                Authenticators.GoogleAuthenticator => _serviceProvider.GetRequiredService<IGoogleAuthenticator>(),
                _ => throw new NotImplementedException()
            };

            var result = authenticator.Create(request.Email);
            
            throw new NotImplementedException();
        }
    }
}
