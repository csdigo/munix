using Munix.Domain.Queries.Query;
using Munix.Domain.Queries.QueryHandle;
using Munix.Domain.Queries.Result;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace Munix.Api.Controllers
{
    public class ClientController : BaseController
    {
        ClientQueryHandle _queryHandle;

        public ClientController(ClientQueryHandle queryHandle)
        {
            _queryHandle = queryHandle;
        }

        // GET: api/Client
        //[ReturnType] IEnumerable<ClientResult>
        public HttpResponseMessage Get()
        {
            return CreateResponse(_queryHandle.Handle(new GetAllQuery()));
        }

        // GET: api/Client/5 
        public HttpResponseMessage Get(Guid id)
        {
            return CreateResponse(_queryHandle.Handle(new GetById(id)));
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
