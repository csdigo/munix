using Munix.Domain.Commands.CommandHandler;
using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Queries.QueryHandle;
using Munix.Domain.Queries.QueryHandler;
using Munix.Infra.Connections;
using Munix.Infra.Repositories;
using SimpleInjector;
using System.Configuration;

namespace Munix.CrossCutting.IoC
{

    public class CustomDependecyResolver
    {
        /// <summary>
        /// Define as dependências do projeto
        /// </summary>
        /// <param name="container"></param>
        public static void Resolve(Container container)
        {
            // Client
            container.Register<IClientRepository, ClientRepository>();
            container.Register<ClientQueryHandler>();
            container.Register<ClientCommandHandler>();

            // CurrencyType
            container.Register<ICurrencyTypeRepository, CurrencyTypeRepository>();
            container.Register<CurrencyTypeQueryHandler>();
            container.Register<CurrencyTypeCommandHandler>();

            // Wallet
            container.Register<IWalletRepository, WalletRepository>();
            container.Register<WalletQueryHandler>();
            container.Register<WalletCommandHandler>();

            // Connection
            container.RegisterInstance(
                new MunixConnection(ConfigurationManager.ConnectionStrings["MuniXConnectionString"].ConnectionString)
            );
        }
    }
}
