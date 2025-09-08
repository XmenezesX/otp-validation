using System.Collections.Concurrent;

namespace OTPValidation.API
{
    public static class ConfigurationOptions
    {
        public static IConfiguration GetConfiguration()
        {
            var configurationBuild = new ConfigurationBuilder();
#if DEBUG
            LoadLocalEnv.Load();
#endif
            configurationBuild.AddInMemoryCollection(new ConcurrentDictionary<string, string?>(
                new Dictionary<string, string?>
                {
                    // Loggin
                    { "Logging:LogLevel:Default", "Information" },
                    { "Logging:LogLevel:Microsoft.AspNetCore", "Error" },
                    { "Logging:LogLevel:System.Net.Http.HttpClient", "Error" },
                    { "Logging:Console:IncludeScopes", "true" },

                    // Postgres
                    { "Connection:Postgres:Host", Environment.GetEnvironmentVariable("CONNECTION_POSTGRES_HOST") },
                    { "Connection:Postgres:Port", Environment.GetEnvironmentVariable("CONNECTION_POSTGRES_PORT") },
                    { "Connection:Postgres:Database", Environment.GetEnvironmentVariable("CONNECTION_POSTGRES_DATABASE") },
                    { "Connection:Postgres:Username", Environment.GetEnvironmentVariable("CONNECTION_POSTGRES_USERNAME") },
                    { "Connection:Postgres:Password", Environment.GetEnvironmentVariable("CONNECTION_POSTGRES_PASSWORD") },

                    // OTP
                    { "OTP:Validation:PeriodValidateInSeconds", Environment.GetEnvironmentVariable("OTP_VALIDATE_IN_SECONDS") },
                    { "OTP:Validation:NumberOfDigits", Environment.GetEnvironmentVariable("OTP_NUMBER_DIGITS") },
                }
            ));
            return configurationBuild.Build();
        }
    }
}
