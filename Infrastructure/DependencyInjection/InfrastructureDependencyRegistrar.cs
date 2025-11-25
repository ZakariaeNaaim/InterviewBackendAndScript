using Application.Interfaces.IRepositories;
using Application.Interfaces;
using Infrastructure.Data.Orders;
using Infrastructure.Data;
using Unity;
using Unity.Lifetime;
using Unity.Injection;

namespace Infrastructure.DependencyInjection
{
    public static class InfrastructureDependencyRegistrar
    {
        public static void Register(IUnityContainer container, string csvPath)
        {
            container.RegisterType<ICsvOrderRepository, CsvOrderRepository>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(csvPath));

            container.RegisterType<IOrdersRepository, OrdersRepository>();
            container.RegisterType<AppDbContext>(new HierarchicalLifetimeManager());
        }
    }
}
