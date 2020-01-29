using OnlineStore.Data.Database;
using OnlineStore.Services.Interfaces;
using OnlineStore.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;
        private readonly StoreContext context;

        public SearchController(ISearchService searchService)
        {
            this.context = new StoreContext();
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string q)
        {
            if (string.IsNullOrEmpty(q))
                return Redirect("~/");

            var products = await searchService.SearchProducts(q.Trim(), context);
            var viewModel = new SearchViewModel { SearchTerm = q.Trim(), Products = products };

            return View(viewModel);
        }
    }
}