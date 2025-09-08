using Microsoft.EntityFrameworkCore;
using OTPValidation.Core.Shared.Infrastructure.Database.Base;
using OTPValidation.Core.Shared.Infrastructure.Database.Entites;
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
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    if (typeof(BaseInfraEntity).IsAssignableFrom(entityType.ClrType))
            //    {
            //        var parameter = Expression.Parameter(entityType.ClrType, "e");
            //        var deletedAtProp = Expression.Property(parameter, nameof(BaseInfraEntity.DeletedAt));
            //        var condition = Expression.Equal(deletedAtProp, Expression.Constant(null, typeof(DateTimeOffset?)));
            //        var lambda = Expression.Lambda(condition, parameter);

            //        modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            //    }
            //}
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseInfraEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var deletedAtProp = Expression.Property(parameter, nameof(BaseInfraEntity.DeletedAt));
                    var nullConstant = Expression.Constant(null, typeof(DateTimeOffset?));
                    var condition = Expression.Equal(deletedAtProp, nullConstant);
                    var lambda = Expression.Lambda(condition, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }

            modelBuilder.Entity<Otp>(entity =>
            {
                entity.ToTable("otp");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .IsRequired();

                entity.Property(e => e.SecretKey)
                    .HasColumnName("secret_key")
                    .IsRequired();

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at");

                entity.Property(e => e.DeletedAt)
                    .HasColumnName("deleted_at");
            });

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
                    entry.State = EntityState.Modified;
                    entry.Entity.DeletedAt = DateTimeOffset.UtcNow;
                }
            }
        }
    }
}
