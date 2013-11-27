using System.Collections.Generic;
using System.Web.Http;
using QuartzPrototype.MyQuartz;

namespace QuartzPrototype.Controllers
{
    public class QuartzController : ApiController
    {
        //Return scheduled jobs
        public IEnumerable<MockJob> Get()
        {
            return Helper.Instace.Jobs;
        } 
    }
}
