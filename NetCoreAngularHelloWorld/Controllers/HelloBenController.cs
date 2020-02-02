using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreAngularHelloWorld.Models;
using NetCoreAngularHelloWorld.Services;

namespace NetCoreAngularHelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloBenController : ControllerBase
    {
        private readonly ILogger<HelloBenController> logger;

        public IService Service { get; }

        // Sort of like magic, stuff gets injected here. It is called IoC aka DI, see Startup.cs
        public HelloBenController(ILogger<HelloBenController> logger, IService service)
        {
            this.logger = logger;
            Service = service;
        }

        [HttpGet]
        [Route("getme")] // so http request to this is http://localhost:{port}/api/HelloBen/getme
        public DataModel GetData()
        {
            return new DataModel
            {
                Key = "From Get",
                Hour = 21,
                Array = new [] { "data1" }
            };
        }

        [HttpPost]
        [Route("stuff/{something}/in")] // http://localhost:{port}/api/HelloBen/stuff/{value}/in?fq=2
        public object PostData([FromRoute] string something, [FromBody] DataModel data, [FromQuery] int fq) // so here 
        {
            return new { Ok = this.Service.DoSomething(data) }; // anonymous objects work, too
        }
    }
}