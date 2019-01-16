using Munix.Domain.Commands.Command.Client;
using Munix.Domain.Commands.CommandHandler;
using Munix.Domain.Queries.Query;
using Munix.Domain.Queries.QueryHandle;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Munix.Api.Controllers
{
    public class ClientController : BaseController
    {
        ClientQueryHandler _queryHandler;
        ClientCommandHandler _commandHandler;

        public ClientController(ClientQueryHandler queryHandle, ClientCommandHandler commandHandler)
        {
            _queryHandler = queryHandle;
            _commandHandler = commandHandler;
        }

        // GET: api/Client
        //[ReturnType] IEnumerable<ClientResult>
        public HttpResponseMessage Get()
        {
            return CreateResponse(_queryHandler.Handle(new GetAllQuery()));
        }

        // GET: api/Client/5 
        public HttpResponseMessage Get(Guid id)
        {
            return CreateResponse(_queryHandler.Handle(new GetById(id)));
        }

        // POST: api/Client
        public HttpResponseMessage Post([FromBody]CreateClientCommand value)
        {
            return CreateResponse(_commandHandler.Handle(value));
        }

        // PUT: api/Client/5
        public HttpResponseMessage Put(Guid id, [FromBody]UpdateClientCommand value)
        {
            value.SetId(id);
            return CreateResponse(_commandHandler.Handle(value));
        }

        // DELETE: api/Client/5
        public HttpResponseMessage Delete(Guid id)
        {
            return CreateResponse(_commandHandler.Handle(new DeleteClientCommand(id)));
        }
    }
}
