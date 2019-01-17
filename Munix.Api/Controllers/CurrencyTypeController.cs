using Munix.Domain.Commands.Command.CurrencyType;
using Munix.Domain.Commands.CommandHandler;
using Munix.Domain.Queries.Query;
using Munix.Domain.Queries.QueryHandler;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Munix.Api.Controllers
{
    public class CurrencyTypeController : BaseController
    {
        CurrencyTypeQueryHandler _queryHandler;
        CurrencyTypeCommandHandler _commandHandler;

        public CurrencyTypeController(CurrencyTypeQueryHandler queryHandle, CurrencyTypeCommandHandler commandHandler)
        {
            _queryHandler = queryHandle;
            _commandHandler = commandHandler;
        }

        // GET: api/CurrencyType
        //[ReturnType] IEnumerable<CurrencyType>
        public HttpResponseMessage Get()
        {
            return CreateResponse(_queryHandler.Handle(new GetAllQuery()));
        }

        // GET: api/CurrencyType/5 
        public HttpResponseMessage Get(Guid id)
        {
            return CreateResponse(_queryHandler.Handle(new GetById(id)));
        }

        // POST: api/CurrencyType
        public HttpResponseMessage Post([FromBody]CreateCurrencyTypeCommand value)
        {
            return CreateResponse(_commandHandler.Handle(value));
        }

        // PUT: api/CurrencyType/5
        public HttpResponseMessage Put(Guid id, [FromBody]UpdateCurrencyTypeCommand value)
        {
            value.Id = id;
            return CreateResponse(_commandHandler.Handle(value));
        }

        // DELETE: api/CurrencyType/5
        public HttpResponseMessage Delete(Guid id)
        {
            return CreateResponse(_commandHandler.Handle(new DeleteCurrencyTypeCommand(id)));
        }
    }
}