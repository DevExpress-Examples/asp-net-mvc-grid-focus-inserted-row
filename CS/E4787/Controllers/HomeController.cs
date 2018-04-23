using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using E4787.Models;

namespace E4787.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial() {
            var model = GetData();
            return PartialView("_GridViewPartial", model);
        }

        public ActionResult AddNew(Entry e) {
            ViewData["newKey"] = e.ID;

            var model = GetData().ToList();
            model.Add(e);
            return PartialView("_GridViewPartial", model);
        }

        private IEnumerable<Entry> GetData() {
            return Enumerable.Range(0, 5).Select(i => new Entry{ ID=i, Text = "Text " + i });
        }

    }
}