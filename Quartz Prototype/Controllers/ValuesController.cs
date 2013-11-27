using System.Globalization;
using System.Web.Http;
using QuartzPrototype.MyQuartz;

namespace QuartzPrototype.Controllers
{
    public class ValuesController : ApiController
    {
        public string Get()
        {
            return Helper.Instace.Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}