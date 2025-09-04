using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OTPValidation.Core.Feature.CreateOtpUseCase;
using OTPValidation.Core.Feature.CreateOtpUseCase.CreateOtpValidation;
using OTPValidation.Core.Shared.Domain.Authenticator;
using OTPValidation.Core.Shared.Domain.Services;
using OTPValidation.Core.Shared.Domain.Services.QrCodeGenerator;

namespace OTPValidation.Core.Shared.Infrastructure.IoC
{
    public static partial class Bootstraper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                   .AddServices(configuration)
                   .UseCases(configuration);
        }

        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IAuthenticatorService, AuthenticatorService>();
            services.AddScoped<IQrCodeGeneratorService, QrCodeGeneratorService>();

            return services;
        }

        private static IServiceCollection UseCases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICreateOtpUseCase, CreateOtpUseCase>();
            services.AddScoped<ICreateOtpValidationUseCase, CreateOtpValidationUseCase>();

            return services;
        }
    }
}
