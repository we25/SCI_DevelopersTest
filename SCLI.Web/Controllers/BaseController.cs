using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SCLI.Web.Controllers
{
    public class BaseController : Controller
    {
        public HttpClient client = new HttpClient();
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            client.BaseAddress = new Uri("http://localhost:5172/");
        }
    }
}
