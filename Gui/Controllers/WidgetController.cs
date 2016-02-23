using System.Web.Mvc;
using Repositories;
using UseCases;

namespace Gui.Controllers
{
    public class WidgetController : Controller
    {
        private readonly IWidgetRepository _repo;
        private readonly IWidgetCase _case;

        public WidgetController()
        {
            _repo = new WidgetRepository();
            _case = new WidgetCase();
        }

        // GET: Widget
        public ActionResult Index()
        {
            return View(_repo.GetAllWidgets());
        }
    }
}