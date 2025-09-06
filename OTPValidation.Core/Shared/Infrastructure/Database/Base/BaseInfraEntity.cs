using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTPValidation.Core.Shared.Infrastructure.Database.Base
{
    public abstract record BaseInfraEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTimeOffset? UpdatedAt { get;set; } = DateTimeOffset.UtcNow;

        [Column("deleted_at")]
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
