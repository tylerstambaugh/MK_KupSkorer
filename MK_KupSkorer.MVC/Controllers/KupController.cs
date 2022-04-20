using MK_KupSkorer.Contracts;
using MK_KupSkorer.Models.KupModels;
using MK_KupSkorer.Models.PlayerModels;
using MK_KupSkorer.Models.RaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            ViewData["Players"] = new SelectList(_playerService.GetActivePlayerList(), "PlayerId", "FirstName");
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
                   // TempData.Add("", $"Kup {kupId} was kreated.");

                    int raceId =  _raceService.CreateRace(new RaceCreate { KupId = kupId });
                    
                   // return Json(Url.Action("UpdateRace", "Race", new {raceId = raceId}));
                    return RedirectToAction("UpdateRace", "Race", new { raceId });
                }
            }
            ModelState.AddModelError("", "Kup could not be created. Please check your inputs and try again.");
            return View(kupCreateModel);
            
        }


        [HttpGet] //GET /kup/ReviewKup
        public ActionResult ReviewKup(int kupId)
        {
            //get list of races for the kup
            var raceList = _raceService.GetRaceDetailListByKupId(kupId);

            //get list of Players for the kup
            var playerList = _playerService.GetPlayerListByKupId(kupId);

            //create list of PlayerKupReviewList obj that will be passed to the view
            List<PlayerKupReviewListItem> playerKupReviewList = new List<PlayerKupReviewListItem>();

            foreach(PlayerListItem pli in playerList)
            {
                if (pli != null)
                {
                    playerKupReviewList.Add(new PlayerKupReviewListItem
                    {
                        PlayerId = pli.PlayerId,
                        PlayerName = pli.FirstName
                    });
                }                
            }

            //update playerKupReviewList with points for each race
            foreach(RaceDetail rd in raceList)
            {
                //need to find the player that was the winner of the race
                //PlayerKupReviewListItem.PlayerId == RaceDetail.WinnerId
               var ptu = playerKupReviewList
                    .Find(p => p.PlayerId == rd.WinnerId);
                if (ptu != null)
                {
                    ptu.PlayerKupWins++;
                    ptu.PlayerKupPoints += 0.25;
                }
            }

            //figure out who to award the bonus point to:
            int bonusPointWinner = _kupService.RewardBonusPoint(kupId);
            if (bonusPointWinner != -1)
            {
                playerKupReviewList.Single(p => p.PlayerId == bonusPointWinner).PlayerKupBonusPoints = 1;
            }

            //Also update the total points and wins for the player
            foreach (PlayerKupReviewListItem p in playerKupReviewList)
            {
                UpdatePlayerPoints upp = new UpdatePlayerPoints
                {
                    PlayerId = p.PlayerId,
                    TotalRacePoints = p.PlayerKupPoints,
                    TotalWins = p.PlayerKupWins,
                    TotalBonusPoints = p.PlayerKupBonusPoints
                };
                _playerService.UpdatePlayerPoints(upp);
            }

           
            return View(playerKupReviewList);
        }

    }
}