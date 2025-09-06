using Microsoft.EntityFrameworkCore;

namespace OTPValidation.Core.Shared.Infrastructure.Database
{
    public sealed class OtpValidationDBContext : DbContext
    {
        public OtpValidationDBContext(DbContextOptions<OtpValidationDBContext> options) : base(options)
        {
        }
    }
}
