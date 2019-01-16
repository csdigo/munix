using Munix.Domain.Contracts.Repositories;
using Munix.Domain.Queries.QueryHandle;
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
            // Cliente
            container.Register<IClientRepository, ClientRepository>();
            container.Register<ClientQueryHandler>();

            // Conexão
            container.RegisterInstance(
                new MunixConnection(ConfigurationManager.ConnectionStrings["MuniXConnectionString"].ConnectionString)
            );
        }
    }
}
