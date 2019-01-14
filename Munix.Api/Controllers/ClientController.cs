using Munix.Domain.Queries.Query;
using Munix.Domain.Queries.QueryHandle;
using Munix.Domain.Queries.Result;
using System.Collections.Generic;
using System.Web.Http;

namespace Munix.Api.Controllers
{
    public class ClientController : ApiController
    {
        ClientQueryHandle _queryHandle;

        public ClientController(ClientQueryHandle queryHandle)
        {
            _queryHandle = queryHandle;
        }

        // GET: api/Client
        public IEnumerable<ClientResult> Get()
        {
            return _queryHandle.Handle(new GetAllQuery());
        }

        // GET: api/Client/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Client
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Client/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}
