using Microsoft.EntityFrameworkCore;
using OTPValidation.Core.Shared.Infrastructure.Database.Base;
using System.Linq.Expressions;

namespace OTPValidation.Core.Shared.Infrastructure.Database
{
    public sealed partial class OtpValidationDBContext : DbContext
    {
        public OtpValidationDBContext() { }
        public OtpValidationDBContext(DbContextOptions<OtpValidationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseInfraEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var deletedAtProp = Expression.Property(parameter, nameof(BaseInfraEntity.DeletedAt));
                    var condition = Expression.Equal(deletedAtProp, Expression.Constant(null, typeof(DateTimeOffset?)));
                    var lambda = Expression.Lambda(condition, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateTimestampsAndSoftDelete();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestampsAndSoftDelete();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestampsAndSoftDelete()
        {
            foreach (var entry in ChangeTracker.Entries<BaseInfraEntity>())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTimeOffset.UtcNow;
                }

                if (entry.State == EntityState.Deleted)
                {
                    // Soft delete
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedAt = DateTimeOffset.UtcNow;
                }
            }
        }
    }
}
