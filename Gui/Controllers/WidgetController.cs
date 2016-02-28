using System;
using System.Web.Mvc;
using Models;
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

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Widget newWidget)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _case.CreateWidget(newWidget.Name, newWidget.Price);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(newWidget);
                }
            }
            catch
            {
                return View(newWidget);
            }
        }
    }
}