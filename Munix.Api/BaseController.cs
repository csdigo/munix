using System.Net.Http;
using System.Web.Http;

namespace Munix.Api
{
    public class BaseController : ApiController
    {
        protected HttpResponseMessage CreateResponse<T>(T obj)
        {
            var response = new HttpResponseMessage();
            
            return response;
        }
    }
}