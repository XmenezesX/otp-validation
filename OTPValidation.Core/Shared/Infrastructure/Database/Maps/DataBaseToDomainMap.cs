using OTPValidation.Core.Shared.Domain.Entites;
using OTPValidation.Core.Shared.Domain.Entites.Base;
using OTPValidation.Core.Shared.Infrastructure.Database.Base;
using OTPValidation.Core.Shared.Infrastructure.Database.Entites;
using System.Collections.Concurrent;

namespace Soollar.Transactional.Core.Shared.Infraestructure.Data.DataBase.PgAdmin.InternalDbContext.Map
{
    public static class DataBaseToDomainMap
    {
        private static IDictionary<Type, Func<BaseInfraEntity, BaseDomainEntity>> _map = new ConcurrentDictionary<Type, Func<BaseInfraEntity, BaseDomainEntity>>();

        static DataBaseToDomainMap()
        {
            _map.Add(typeof(Otp), (infraBaseDomainEntity) =>
            {
                var infraEntity = infraBaseDomainEntity as Otp;
                return OtpEntity.Restore(
                    infraEntity!.Id,
                    infraEntity.Email,
                    infraEntity.SecretKey,
                    infraEntity.CreatedAt,
                    infraEntity.UpdatedAt,
                    infraEntity.DeletedAt);
            });
        }
        public static BaseDomainEntity Map(BaseInfraEntity infraBaseDomainEntity)
        {
            return _map[infraBaseDomainEntity.GetType()](infraBaseDomainEntity);
        }
    }
}
