using Application.Interfaces.IServices;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Application.DependencyInjection
{
    public static class ApplicationDependencyRegistrar
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IOrdersService, OrdersService>();
            container.RegisterType<IMetricsService, MetricsService>();
        }
    }
}
