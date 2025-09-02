using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;

namespace OTPValidation.Core.Shared.Infrastructure.Crosscuting.UseCase
{
    public interface IUseCase <T>
    {
        Task<IOperation> ExecAsync(T request, CancellationToken cancellationToken);
    }
}
