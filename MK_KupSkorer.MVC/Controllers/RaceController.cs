using MK_KupSkorer.Contracts;
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

        // GET: Race
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet] //GET /race/UpdateRace
        public ActionResult UpdateRace(int raceId)
        {
            ViewBag.Players = new SelectList(_playerService.GetPlayerIdsByKupId(_raceService.GetRaceById(raceId).KupId), "PlayerId", "Player");
            var raceToUpdate = _raceService.GetRaceById(raceId);
            return View(raceToUpdate);
        }
    }
}