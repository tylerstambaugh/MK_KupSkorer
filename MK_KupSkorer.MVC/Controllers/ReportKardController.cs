using MK_KupSkorer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK_KupSkorer.MVC.Controllers
{
    [Authorize]
    public class ReportKardController : Controller
    {
        private readonly IReportKardService _reportKardSerivce;

        public ReportKardController(IReportKardService svc)
        {
            _reportKardSerivce = svc;
        }
        // GET: ReportKard
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet] //GET: /ReportKard/Racers
        public ActionResult Racers()
        {
            var model = _reportKardSerivce.GetRacerReportKard();
            return View(model);
        }

    }
}