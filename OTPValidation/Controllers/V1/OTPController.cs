using Microsoft.AspNetCore.Mvc;
using OTPValidation.Core.Feature.CreateOtpUseCase;
using OTPValidation.Core.Feature.ValidateOtpUseCase;
using OTPValidation.Core.Shared.Domain.Request;
using OTPValidation.Core.Shared.Infrastructure.Crosscuting.Utils;

namespace OTPValidation.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/otp")]
    public sealed class OTPController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOTPAsync([FromBody] CreateOtpRequest request,
                                                        [FromServices] ICreateOtpUseCase useCase,
                                                        CancellationToken cancellationToken)
        {
            return this.DefaultResult(await useCase.Exec(request, cancellationToken));
        }

        //[HttpPost("validate")]
        //public IActionResult ValidateOTPAsync([FromBody] ValidateOtpRequest request,
        //                                      [FromServices] IValidateOtpUseCase useCase,
        //                                      CancellationToken cancellationToken)
        //{

        //    var result = useCase.Exec(request, cancellationToken);
        //    return File(result, "image/png");
        //}
    }
}
