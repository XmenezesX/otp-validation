using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OTPValidation.Core.Feature.CreateOtpUseCase;
using OTPValidation.Core.Feature.CreateOtpUseCase.CreateOtpValidation;
using OTPValidation.Core.Feature.ValidateOtpUseCase;
using OTPValidation.Core.Feature.ValidateOtpUseCase.Validation;
using OTPValidation.Core.Shared.Domain.Authenticator;
using OTPValidation.Core.Shared.Domain.Repository;
using OTPValidation.Core.Shared.Domain.Services;
using OTPValidation.Core.Shared.Infrastructure.Database;
using OTPValidation.Core.Shared.Infrastructure.Options;
using OTPValidation.Core.Shared.Infrastructure.Repository;

namespace OTPValidation.Core.Shared.Infrastructure.IoC
{
    public static partial class Bootstraper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                   .AddOptions(configuration)
                   .AddServices(configuration)
                   .AddRepositorys(configuration)
                   .AddUseCases(configuration)
                   .AddPostgreDatabase(configuration);
        }

        private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<PostgresDbOptions>().Bind(configuration.GetSection(PostgresDbOptions.SectionName));
            services.AddOptions<OtpOptions>().Bind(configuration.GetSection(OtpOptions.SectionName));

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOtpService, OtpService>();
            services.AddScoped<IAuthenticator, Authenticator>();

            return services;
        }

        private static IServiceCollection AddRepositorys(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOtpRepository, OtpRepository>();

            return services;
        }

        private static IServiceCollection AddUseCases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICreateOtpUseCase, CreateOtpUseCase>();
            services.AddScoped<ICreateOtpValidationUseCase, CreateOtpValidationUseCase>();

            services.AddScoped<IValidateOtpUseCase, ValidateOtpUseCase>();
            services.AddScoped<IValidateOtpValidationUseCase, ValidateOtpValidationUseCase>();

            return services;
        }

        private static IServiceCollection AddPostgreDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var postgresOptions = configuration.GetSection(PostgresDbOptions.SectionName).Get<PostgresDbOptions>();
            services.AddDbContext<OtpValidationDBContext>(options =>
            {
                var connectionString = postgresOptions!.BuildConnectionString();
                options.UseNpgsql(connectionString);
                
            });

            return services;
        }
    }
}
