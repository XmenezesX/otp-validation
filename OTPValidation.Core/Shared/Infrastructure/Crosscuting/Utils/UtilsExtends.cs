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

        public static IActionResult DefaultResult(this ControllerBase controller, IOperation operation)
        {
            if (operation.IsFail())
                return controller.BadRequest(operation);
            
            return controller.Ok(operation);
        }
    }
}
