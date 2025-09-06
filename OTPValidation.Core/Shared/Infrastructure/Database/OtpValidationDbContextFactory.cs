using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using OTPValidation.Core.Shared.Infrastructure.Options;

namespace OTPValidation.Core.Shared.Infrastructure.Database
{
    public sealed class OtpValidationDbContextFactory : IDesignTimeDbContextFactory<OtpValidationDBContext>
    {
        public OtpValidationDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OtpValidationDBContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=otp-validation;Username=postgres;Password=1234");
            return new OtpValidationDBContext(optionsBuilder.Options);
        }
    }
}
