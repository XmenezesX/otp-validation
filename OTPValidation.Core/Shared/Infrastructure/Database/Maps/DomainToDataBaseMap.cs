using OTPValidation.Core.Shared.Domain.Entites;
using OTPValidation.Core.Shared.Domain.Entites.Base;
using OTPValidation.Core.Shared.Infrastructure.Database.Base;
using OTPValidation.Core.Shared.Infrastructure.Database.Entites;
using System.Collections.Concurrent;

namespace Soollar.Transactional.Core.Shared.Infraestructure.Data.DataBase.PgAdmin.InternalDbContext.Map
{

    public static class DomainToDataBaseMap
    {

        private static IDictionary<Type, Func<BaseDomainEntity, BaseInfraEntity>> _map = new ConcurrentDictionary<Type, Func<BaseDomainEntity, BaseInfraEntity>>();

        static DomainToDataBaseMap()
        {
            _map.Add(typeof(OtpEntity), (entity) =>
            {
                var domainEntity = entity as OtpEntity;
                return new Otp
                {
                    Id = domainEntity!.Id,
                    Email = domainEntity.Email,
                    SecretKey = domainEntity.SecretKey,
                    DeletedAt = domainEntity.DeletedAt,
                    CreatedAt = domainEntity.CreatedAt,
                    UpdatedAt = domainEntity.UpdatedAt
                };
            });
        }

        public static BaseInfraEntity Map(BaseDomainEntity entity)
        {
            return _map[entity.GetType()](entity);
        }
    }
}
