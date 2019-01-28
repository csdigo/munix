using Munix.Domain.Commands.Command.Wallet;
using Munix.Domain.Commands.CommandHandler;
using Munix.Domain.Queries.Query;
using Munix.Domain.Queries.QueryHandler;
using System;
using System.Net.Http;
using System.Web.Http;

namespace Munix.Api.Controllers
{
    public class WalletController : BaseController
    {
        WalletCommandHandler _commandHandler;
        WalletQueryHandler _queryHandler;

        public WalletController(WalletCommandHandler commandHandler, WalletQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        // GET: api/Wallet
        //[ReturnType] IEnumerable<WalletResult>
        public HttpResponseMessage Get()
        {
            return CreateResponse(_queryHandler.Handle(new GetAllQuery()));
        }

        // GET: api/Wallet/5 
        public HttpResponseMessage Get(Guid id)
        {
            return CreateResponse(_queryHandler.Handle(new GetById(id)));
        }

        // POST: api/Wallet
        public HttpResponseMessage Post([FromBody]CreateWalletCommand value)
        {
            return CreateResponse(_commandHandler.Handle(value));
        }

        // PUT: api/Wallet/5
        public HttpResponseMessage Put(Guid id, [FromBody]UpdateWalletCommand value)
        {
            value.Id = id;
            return CreateResponse(_commandHandler.Handle(value));
        }

        // DELETE: api/Wallet/5
        public HttpResponseMessage Delete(Guid id)
        {
            return CreateResponse(_commandHandler.Handle(new DeleteWalletCommand(id)));
        }
    }
}
