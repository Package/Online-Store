using OnlineStore.Data.Database;
using OnlineStore.Data.Models;
using OnlineStore.Services.Implementation;
using OnlineStore.Services.Interfaces;
using OnlineStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IProductService productService;
        private readonly IBasketService basketService;
        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;
        private readonly IAddressService addressService;
        private readonly StoreContext context;

        public CheckoutController(
            IProductService productService, 
            IBasketService basketService,
            IOrderService orderService,
            ICustomerService customerService,
            IAddressService addressService)
        {
            this.context = new StoreContext();
            this.productService = productService;
            this.basketService = basketService;
            this.orderService = orderService;
            this.customerService = customerService;
            this.addressService = addressService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var products = basketService.GetProductsInBasket();
            var viewModel = new CheckoutViewModel { ProductsInBasket = products };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Index(CheckoutViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var customer = await customerService.GetCustomerByName(User.Identity.Name, context);

            // Save the address for this customer
            viewModel.Address.Customer = customer;
            await addressService.SaveAddress(viewModel.Address, context);

            // Create the order for this set of products
            var order = orderService.CreateOrder(customer, viewModel.Address);
            await orderService.SaveOrder(order, context);

            // Clear shopping basket
            basketService.ClearBasket();

            return View("Complete", order);
        }
    }
}