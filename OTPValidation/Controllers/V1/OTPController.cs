using Microsoft.AspNetCore.Mvc;
using OTPValidation.Core.Feature.CreateOtpUseCase;
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
                                                        [FromServices] IServiceProvider serviceProvider,
                                                        CancellationToken cancellationToken)
        {

            return this.DefaultResult(await serviceProvider.GetRequiredService<ICreateOtpUseCase>()
                                                           .ExecAsync(request, cancellationToken));
        }
    }
}
