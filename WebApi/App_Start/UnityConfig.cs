using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.Services;
using Infrastructure.Data;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<AppDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IOrdersRepository, OrdersRepository>();
            container.RegisterType<IOrdersService, OrdersService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}