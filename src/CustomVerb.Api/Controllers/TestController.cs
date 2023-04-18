using CustomVerb.Api.Attributes.HttpMethod;
using CustomVerb.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomVerb.Api.Controllers
{
    [ApiController]
    [Route(Constants.Routes.TestRoutes.Prefix)]
    [Produces(System.Net.Mime.MediaTypeNames.Application.Json)]
    [Consumes(System.Net.Mime.MediaTypeNames.Application.Json)]
    public class TestController : ControllerBase
    {
        [HttpNotify]
        [Route(Constants.Routes.TestRoutes.Notify)]
        public IActionResult Notify() => Ok(new NotifyModel("Shizz went down."));

        [HttpSubscribe]
        [Route(Constants.Routes.TestRoutes.Subscribe)]
        public IActionResult Subscribe([FromBody] SubscribeModel model) => Accepted(model);
    }
}