using System.Web.Http;


namespace Location.Service.Controllers
{
    [RoutePrefix("livecheck")]
    public class LiveCheckController : ApiController
    {
        [HttpGet]
        [Route("")]
        public string LiveCheck()
        {
            return "Alive";
        }
    }
}
