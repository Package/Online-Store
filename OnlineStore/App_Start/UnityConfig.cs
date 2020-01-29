using OnlineStore.Controllers;
using OnlineStore.Services.Implementation;
using OnlineStore.Services.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace OnlineStore
{
    // Unity MVC5 Dependency Injection
    // https://dotnettutorials.net/lesson/unity-container-asp-net-mvc/
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // Account controller is a bit special
            container.RegisterType<AccountController>(new InjectionConstructor());

            // Services
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IBasketService, BasketService>();
            container.RegisterType<ISearchService, SearchService>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IAddressService, AddressService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}