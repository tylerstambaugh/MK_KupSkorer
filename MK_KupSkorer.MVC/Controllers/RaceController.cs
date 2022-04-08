using MK_KupSkorer.Contracts;
using MK_KupSkorer.Models.RaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK_KupSkorer.MVC.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceService _raceService;
        private readonly IKupService _kupService;
        private readonly IPlayerService _playerService;

        public RaceController(IKupService kupService, IPlayerService playerService, IRaceService raceService)
        {
            _kupService = kupService;
            _playerService = playerService;
            _raceService = raceService;
        }

        [HttpGet] //GET /race/UpdateRace
        public ActionResult UpdateRace(int raceId)
        {
            ViewData["Players"] = new SelectList(_playerService.GetPlayerListByKupId(_raceService.GetRaceById(raceId).KupId), "PlayerId", "FirstName");
            var raceToUpdate = _raceService.GetRaceById(raceId);
            return View(raceToUpdate);
        }

        //POST /Race/UpdateRace
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateRace(UpdateRace updateRaceModel)
        {
            //set something in viewbag / viewdata to be able to display the race number on the page

            return View();
        }
    }
}