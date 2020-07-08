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

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "user";
        }

        [HttpPost]
        public ActionResult<ReconsultationResponse> Reconsultation([FromBody] ReConsultationRequest reConsultationRequest)
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
            }
            return reConsultationResponse;
        }

    }
}
