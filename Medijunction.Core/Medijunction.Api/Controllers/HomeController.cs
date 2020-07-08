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
    public class HomeController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<string> Index()
        {
            return "Medijunction API is up and running";
        }
    }
}
