namespace OTPValidation.Core.Shared.Domain.Authenticator
{
    public interface IAuthenticator
    {
        (string secretKey, string otpUri) Create(string email);
        bool Validate(string code, string secretKey);
    }
}
