using OTPValidation.Core.Shared.Domain.Entites;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;

namespace OTPValidation.Core.Shared.Domain.Repository
{
    public interface IOtpRepository
    {
        Task<IOperation<Guid>> CreateAsync(OtpEntity entity);
        Task<IOperation<OtpEntity>> SelectByIdAsync(Guid id);
    }
}
