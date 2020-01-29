using System.Web.Mvc;

namespace OnlineStore.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Index(string q)
        {
            if (string.IsNullOrEmpty(q))
                return Redirect("~/");
            
            return View();
        }
    }
}