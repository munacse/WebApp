using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp.Core;

namespace WebApp.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        [Route("")]
        public HttpResponseMessage Post(Student student)
        {
            return this.Request.CreateResponse(
                HttpStatusCode.OK);
        }
    }
}
