using GoogleMap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoogleMap.Controllers
{
    public class HomeController : Controller
    {
        TestDbEntities context = new TestDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.ListOfDropdown = context.google_map.ToList();
            return View();
        }
        public JsonResult GetAllLocation()
        {
            var data = context.google_map.ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllLocationById(int id)
        {
            var data = context.google_map.Where(x => x.Id == id).SingleOrDefault();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        
    }
}