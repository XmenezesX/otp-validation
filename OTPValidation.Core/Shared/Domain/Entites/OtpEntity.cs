using OTPValidation.Core.Shared.Domain.Entites.Base;

namespace OTPValidation.Core.Shared.Domain.Entites
{
    public sealed record OtpEntity : BaseDomainEntity
    {
        public string Email { get; init; }
        public string SecretKey { get; init; }
        
        public OtpEntity() { }
        public static OtpEntity ConceptualCreate(string email, string secretkey)
        {
            return new()
            {
                Id = Guid.Empty,
                Email = email,
                SecretKey = secretkey
            };
        }

        public static OtpEntity Restore(
           in Guid id,
           string email,
           string secretkey,
           in DateTimeOffset createdAt,
           in DateTimeOffset? updatedAt,
           in DateTimeOffset? deletedAt
        )
        {
            return new()
            {
                Id = id,
                Email = email,
                SecretKey = secretkey,
                CreatedAt = createdAt,
                UpdatedAt = updatedAt,  
                DeletedAt = deletedAt
            };
        }
    }
}
