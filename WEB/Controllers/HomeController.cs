using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ResourceModels.Models;
using WEB.Helper;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";
            var intial = new InitialController();
            var node = await intial.Index(new ContextResource() { Ip = "111", Lob = "Cycle", UserType = "Customer", Zip = "12345" });
            var firstOrDefault = node.Find(n => n.nodename.StartsWith(Constants.nextrel))._links.FirstOrDefault();
            if (firstOrDefault != null)
            {
                var workFlowId = GuidHelper.FindFirstGuid(firstOrDefault.href);
                System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie(Constants.WorkFlowId, workFlowId.ToString("N")));
                var url = firstOrDefault.href.Replace(workFlowId.ToString("D"), "icliq");
                var route = new RouteValueDictionary {{"id", url}};
                return RedirectToAction("Index", "NB");
            }
            else
            {
                return View("Index", "Error");
            }
           
        }
        public PartialViewResult GetPartialView(string name)
        {
            return PartialView(name);
        }
    }
}
