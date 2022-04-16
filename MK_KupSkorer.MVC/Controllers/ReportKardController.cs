using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK_KupSkorer.MVC.Controllers
{
    public class ReportKardController : Controller
    {
        // GET: ReportKard
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet] //GET: /ReportKard/RacersByTotalPoints
        public ActionResult RacersByTotalPoints()
        {
            return View();
        }

        [HttpGet] //GET: /ReportKard/RacersByTotalPoints
        public ActionResult RacersByTotalWins()
        {
            return View();
        }
    }
}