using System.Web.Mvc;
using Repositories;
using UseCases;

namespace Gui.Controllers
{
    public class WidgetController : Controller
    {
        private readonly IWidgetCase _case;

        public WidgetController()
        {
            _case = new WidgetCase(new WidgetRepository());
        }

        // GET: Widget
        public ActionResult Index()
        {
            return View(_case.GetAllWidgets());
        }
    }
}