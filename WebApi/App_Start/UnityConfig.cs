using Application.DependencyInjection;
using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Data.Orders;
using Infrastructure.DependencyInjection;
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
        private const string OrdersCsvPath = "~/App_Data/orders.csv";
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            var csvPath = HttpContext.Current.Server.MapPath(OrdersCsvPath);

            InfrastructureDependencyRegistrar.Register(container, csvPath);
            ApplicationDependencyRegistrar.Register(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}