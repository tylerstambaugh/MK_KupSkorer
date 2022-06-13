using MK_KupSkorer.Contracts;
using MK_KupSkorer.Models.RaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK_KupSkorer.MVC.Controllers
{
    [Authorize]
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

        [HttpGet] //GET /Race/UpdateRace
        public ActionResult UpdateRace(int raceId)
        {
            ViewBag.RaceNumber = _raceService.GetKupRaceCountByRaceId(raceId);

            ViewData["Players"] = new SelectList(_playerService.GetPlayerListByKupId(_raceService.GetRaceById(raceId).KupId), "PlayerId", "FirstName");

            RaceDetail raceToUpdate = _raceService.GetRaceById(raceId);

            return View(raceToUpdate);
        }

        //POST /Race/UpdateRace
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateRace(UpdateRace updateRaceModel, int raceId)
        {
            var currentRace = _raceService.GetRaceById(raceId);

            if (_raceService.IsLastRace(raceId))
            {
                _raceService.UpdateRace(updateRaceModel, raceId);
                return RedirectToAction("AwardKupBonusPoint", "Kup", new { kupId = currentRace.KupId });
            }

            //increment the race count on the Kup
            _kupService.IncrementKupRaceCount(currentRace.KupId);

            //update the current race
            _raceService.UpdateRace(updateRaceModel, raceId);

            //Create a new race to pass back to the view
            int nextRaceId = _raceService.CreateRace(new RaceCreate { KupId = currentRace.KupId });

            //Provide race count to view
            ViewBag.RaceNumber = _raceService.GetKupRaceCountByRaceId(raceId);
            //Provide players to view
            ViewData["Players"] = new SelectList(_playerService.GetPlayerListByKupId(currentRace.KupId), "PlayerId", "FirstName");

            //redirect back to UpdateRace to update the newly created race
            return RedirectToAction("UpdateRace", "Race", new { raceId = nextRaceId  } );
        }
    }
}