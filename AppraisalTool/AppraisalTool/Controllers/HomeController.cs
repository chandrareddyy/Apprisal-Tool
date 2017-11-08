using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Appraisal.Services;

namespace AppraisalTool.Controllers
{
    public class HomeController : Controller
    {
        private IValuesService _valuesService;

        public HomeController(IValuesService valuesService)
        {
            _valuesService = valuesService;
        }
        public ActionResult Index()
        {
            var departments = _valuesService.GetAllValues();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}