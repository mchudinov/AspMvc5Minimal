using System;
using System.Net;
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

        [HttpGet]
        public ActionResult Index()
        {
            return View(_case.GetWidgets());
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Widget widget = _case.GetWidget(new Guid(id));
            if (widget == null)
            {
                return HttpNotFound();
            }
            return View(widget);
        }

        #region Create
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
        #endregion

        #region Delete
        [HttpGet]
        public ActionResult Delete(string id)
        {
            Widget widget = _case.GetWidget(new Guid(id));
            if (widget == null)
            {
                return HttpNotFound();
            }
            return View(widget);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            _case.DeleteWidget(new Guid(id));
            return RedirectToAction("Index");
        }
        #endregion

        #region Edit
        [HttpGet]

        public ActionResult Edit(string id)
        {
            Widget widget = _case.GetWidget(new Guid(id));
            if (widget == null)
            {
                return HttpNotFound();
            }
            return View(widget);
        }

        [HttpPost]
        public ActionResult Edit(Widget widget)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _case.UpdateWidget(widget);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(widget);
                }
            }
            catch
            {
                return View(widget);
            }
        }
        #endregion
    }
}