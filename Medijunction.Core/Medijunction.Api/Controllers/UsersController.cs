using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediJunction.Process.Contracts;
using MediJunction.ServiceModel;
using MediJunction.ServiceModel.Response;
using Microsoft.AspNetCore.Mvc;

namespace Medijunction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserProcess _userProcess;

        public UsersController(IUserProcess userProcess)
        {
            _userProcess = userProcess;
        }

        /// <summary>
        /// This endpoint is used for reconsultation
        /// </summary>
        /// <param name="reConsultationRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/reconsultation")]
        public ActionResult<ReconsultationResponse> Reconsultation([FromBody] ReConsultationRequest reConsultationRequest)
        {
            try
            {
                var reConsultationResponse = _userProcess.Reconsultation(reConsultationRequest);
                switch (reConsultationResponse.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        return Ok(reConsultationResponse);
                    case System.Net.HttpStatusCode.NotFound:
                        return NotFound(reConsultationResponse);
                    case System.Net.HttpStatusCode.BadRequest:
                        return BadRequest(reConsultationResponse);
                    case System.Net.HttpStatusCode.Conflict:
                        return Conflict(reConsultationResponse);
                    default:
                        return Ok();
                }
            }
            catch (Exception exception)
            {
                var exceptionResponse = new ExceptionResponse { DeveloperMessage = exception.StackTrace, ExceptionMessage = exception.Message };
                return new ObjectResult(exceptionResponse){ StatusCode = (int) System.Net.HttpStatusCode.InternalServerError };
            }
        }

    }
}
