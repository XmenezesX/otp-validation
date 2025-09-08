using Microsoft.EntityFrameworkCore;
using OTPValidation.Core.Shared.Domain.Entites;
using OTPValidation.Core.Shared.Domain.Repository;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.NotificationError;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;
using OTPValidation.Core.Shared.Infrastructure.Database;
using OTPValidation.Core.Shared.Infrastructure.Database.Entites;
using Soollar.Transactional.Core.Shared.Infraestructure.Data.DataBase.PgAdmin.InternalDbContext.Map;

namespace OTPValidation.Core.Shared.Infrastructure.Repository
{
    public sealed class OtpRepository(OtpValidationDBContext _dbContext) : IOtpRepository
    {
        public async Task<IOperation<Guid>> CreateAsync(OtpEntity entity)
        {
            var infraEntity = (Otp)DomainToDataBaseMap.Map(entity);
            
            await _dbContext.Otp.AddAsync(infraEntity);
            await _dbContext.SaveChangesAsync();

            return infraEntity.Id.AsSuccess();
        }

        public async Task<IOperation<OtpEntity>> SelectByIdAsync(Guid id)
        {
            var entityInfra = await  _dbContext.Otp.AsNoTracking()
                                              .FirstOrDefaultAsync(x => x.Id == id);
            if (entityInfra is null)
            {
                Console.WriteLine("Entidade é nula");
                return OperationFactory.CreateFail<OtpEntity>(NotificationErrors.Create(nameof(entityInfra), "Entidade nao encontrada!"));
            }
            var entity = (OtpEntity)DataBaseToDomainMap.Map(entityInfra);
            return entity.AsSuccess();
        }
    }
}
