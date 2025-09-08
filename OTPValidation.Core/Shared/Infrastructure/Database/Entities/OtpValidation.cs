using System.ComponentModel.DataAnnotations;

namespace OTPValidation.Core.Shared.Infrastructure.Database.Entities
{
    public sealed class OtpValidation
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        public string SecretKey { get; set; }
        public DateTimeOffset Created { get; set; }
    }
}
