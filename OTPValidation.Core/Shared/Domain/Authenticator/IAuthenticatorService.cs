namespace OTPValidation.Core.Shared.Domain.Authenticator
{
    public interface IAuthenticatorService
    {
        (string base32Secret, string otpUrl) Create(string email);
        bool Validate(string code, string secretKey);
    }
}
