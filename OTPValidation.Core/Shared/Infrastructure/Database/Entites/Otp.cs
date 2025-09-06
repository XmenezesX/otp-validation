using OTPValidation.Core.Shared.Infrastructure.Database.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTPValidation.Core.Shared.Infrastructure.Database.Entites
{
    [Table("otp")]
    public sealed record Otp : BaseInfraEntity
    {
        [Column("email")]
        public string Email { get; set; }

        [Column("secret_key")]
        public string SecretKey { get; set; }
    }
}
