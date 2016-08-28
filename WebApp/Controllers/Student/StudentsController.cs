
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApp.Service.BAL;

namespace WebApp.Controllers
{
    [RoutePrefix("api/students")]
    public class StudentsController : ApiController
    {
        [Route("")]
        public async Task<HttpResponseMessage> Post(StudentCreateCommand student)
        {
            StudentCreateHandler handle = new StudentCreateHandler();
            return await handle.Handle(student);
        }
    }
}
