using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;

namespace OTPValidation.Core.Shared.Domain.Authenticator
{
    public interface IAuthenticatorService
    {
        (string base32Secret, string otpUrl) Create(string email);
        Task<IOperation> Validate(string value);
    }
}
