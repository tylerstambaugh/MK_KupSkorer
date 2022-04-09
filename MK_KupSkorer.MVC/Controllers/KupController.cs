using MK_KupSkorer.Contracts;
using MK_KupSkorer.Models.KupModels;
using MK_KupSkorer.Models.RaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK_KupSkorer.MVC.Controllers
{
    [Authorize]
    public class KupController : Controller
    {
        private readonly IKupService _kupService;
        private readonly IPlayerService _playerService;
        private readonly IRaceService _raceService;

        public KupController(IKupService kupService, IPlayerService playerService, IRaceService raceService)
        {
            _kupService = kupService;
            _playerService = playerService;
            _raceService = raceService;
        }

        [HttpGet] //GET /kup/startKup
        public ActionResult StartKup()
        {
            ViewData["Players"] = new SelectList(_playerService.GetPlayerList(), "PlayerId", "FirstName");
            return View();
        }

        [HttpPost] //POST /kup/startKup
        [ValidateAntiForgeryToken]
        public ActionResult StartKup(KupCreate kupCreateModel)
        {
            if(ModelState.IsValid)
            {
                int kupId = _kupService.CreateKup(kupCreateModel);
                if (kupId != -1)
                {
                    TempData.Add("", $"Kup {kupId} was kreated.");

                    int raceId = _raceService.CreateRace(new RaceCreate { KupId = kupId });

                    return RedirectToAction("UpdateRace", "Race", new { raceId });
                }
            }
            ModelState.AddModelError("", "Kup could not be created. Please check your inputs and try again.");
            return View(kupCreateModel);
            
        }


        [HttpGet] //GET /kup/UpdateKup
        public ActionResult UpdateKup(int kupId)
        {
            return View();
        }

        [HttpPost]  //POSt /kup/updateKup
        [ValidateAntiForgeryToken]
        public ActionResult UpdateKup(UpdateKup updateKupModel, UpdateRace updateRaceModel)
        {
            if (!ModelState.IsValid)
                return View(updateKupModel);

            return View();
        }
    }
}