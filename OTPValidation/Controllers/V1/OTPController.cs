using Microsoft.AspNetCore.Mvc;
using OTPValidation.Core.Feature.CreateOtpUseCase;
using OTPValidation.Core.Feature.ValidateOtpUseCase;
using OTPValidation.Core.Shared.Domain.Request;

namespace OTPValidation.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/otp")]
    public sealed class OTPController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateOTPAsync([FromBody] CreateOtpRequest request,
                                              [FromServices] ICreateOtpUseCase useCase,
                                              CancellationToken cancellationToken)
        {

            var result = useCase.Exec(request, cancellationToken);
            return File(result, "image/png");
        }

        [HttpPost("validate")]
        public IActionResult ValidateOTPAsync([FromBody] ValidateOtpRequest request,
                                              [FromServices] IValidateOtpUseCase useCase,
                                              CancellationToken cancellationToken)
        {

            var result = useCase.Exec(request, cancellationToken);
            return File(result, "image/png");
        }
    }
}
