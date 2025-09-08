using Microsoft.Extensions.DependencyInjection;
using OTPValidation.Core.Shared.Domain.Authenticator;
using OTPValidation.Core.Shared.Domain.Entites;
using OTPValidation.Core.Shared.Domain.Repository;
using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Domain.Response;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;

namespace OTPValidation.Core.Shared.Domain.Services
{
    public sealed class OtpService(IServiceProvider _serviceProvider) : IOtpService
    {
        public async Task<IOperation<CreateOtpResponse>> CreateOtpAsync(CreateOtpRequest request)
        {
            var (secretKey, otpUri) = _serviceProvider.GetRequiredService<IAuthenticator>()
                                                      .Create(request.Email);

            var entity = OtpEntity.ConceptualCreate(request.Email, secretKey);
            var result = await _serviceProvider.GetRequiredService<IOtpRepository>()
                                               .CreateAsync(entity);
            if (result.IsFail())
                throw new Exception("aconteceu merda");
            
            var id = result.SucessAs<Guid>();
            var response = new CreateOtpResponse()
            {
                OtpUri = otpUri,
                ValidationId = id
            };

            return response.AsSuccess();
        }

        public async Task<IOperation<ValidationOtpResponse>> ValidateOtp(ValidateOtpRequest request)
        {
            var operationEntity = await _serviceProvider.GetRequiredService<IOtpRepository>()
                                                        .SelectByIdAsync(request.ValidationId);
            if (operationEntity.IsFail())
            {
                Console.WriteLine("[OtpEntity] - Registro não encontrado");
                return operationEntity.AsFail<ValidationOtpResponse>();
            }
            
            var otpEntity = operationEntity.SucessAs<OtpEntity>();
            var result = _serviceProvider.GetRequiredService<IAuthenticator>()
                                         .Validate(request.Code, otpEntity.SecretKey);
            var response = new ValidationOtpResponse()
            {
                IsValid = result,
                Message = result ? "Validação realizada com sucesso!" : "Código inválido"
            };

            return response.AsSuccess();
        }
    }
}
