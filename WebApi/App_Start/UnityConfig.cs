using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Data.Orders;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace WebApi
{
    public static class UnityConfig
    {
        const string ordersCsvPath = "~/App_Data/orders.csv";
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ICsvOrderRepository, CsvOrderRepository>(
                new ContainerControlledLifetimeManager(),
               new InjectionConstructor(HttpContext.Current.Server.MapPath(ordersCsvPath))
           );

            container.RegisterType<AppDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrdersRepository, OrdersRepository>();
            container.RegisterType<IOrdersService, OrdersService>();
            container.RegisterType<IMetricsService, MetricsService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}