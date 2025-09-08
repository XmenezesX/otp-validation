namespace OTPValidation.Core.Shared.Domain.Entites.Base
{
    public abstract record BaseDomainEntity
    {
        public Guid Id { get; protected init; } = Guid.NewGuid();
        public DateTimeOffset CreatedAt { get; protected init; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? UpdatedAt { get; protected init; }
        public DateTimeOffset? DeletedAt { get; protected init; }

        public BaseDomainEntity MarkAsUpdated() =>
            this with { UpdatedAt = DateTimeOffset.UtcNow };

        public BaseDomainEntity MarkAsDeleted() =>
            this with { DeletedAt = DateTimeOffset.UtcNow };
    }
}
