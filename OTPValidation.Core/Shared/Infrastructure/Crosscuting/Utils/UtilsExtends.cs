using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OTPValidation.Core.Shared.Infrastructure.CrossCutting.Operation;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace OTPValidation.Core.Shared.Infrastructure.Crosscuting.Utils
{
    public static class UtilsExtends
    {
        public static bool IsValidEmail(this string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
			{
                var mailAddress = new MailAddress(email);
                return true;
            }
			catch (Exception)
			{
                return false;
			}
        }

        public static string ToBase64(this byte[] bytes) 
        {
            return Convert.ToBase64String(bytes); 
        }

        public static byte[] FromBase64(this string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
                throw new ArgumentException("A string Base64 não pode ser nula ou vazia");

            return Convert.FromBase64String(base64String);
        }
        public static IActionResult DefaultResult(this ControllerBase controller, IOperation operation)
        {
            if (operation.IsFail())
                return controller.BadRequest(operation);
            
            return controller.Ok(operation);
        }
    }
}
