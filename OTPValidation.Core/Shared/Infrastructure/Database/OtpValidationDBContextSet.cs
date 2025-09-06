using Microsoft.EntityFrameworkCore;
using OTPValidation.Core.Shared.Infrastructure.Database.Entites;

namespace OTPValidation.Core.Shared.Infrastructure.Database
{
    public sealed partial class OtpValidationDBContext
    {
        public DbSet<Otp> Otp { get; set; }
    }
}
