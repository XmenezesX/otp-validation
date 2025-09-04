using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;

namespace OTPValidation.Core.Shared.Domain.Services.QrCodeGenerator
{
    public interface IQrCodeGeneratorService
    {
        byte[] Generate(string information);
    }
}
