using System.Web.Http;

namespace QuartzPrototype.Controllers
{
    public class HomeController : ApiController
    {
        public string Get()
        {
            return "Quartz prototype";
        }
    }
}
