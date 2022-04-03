using MK_KupSkorer.Contracts;
using MK_KupSkorer.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MK_KupSkorer.MVC.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

       
        [HttpGet]  // GET: Player/Index
        public ActionResult Index()
        {
            var model = _playerService.GetPlayerList();
            return View(model);
        }

        [HttpGet] //GET" Player/Create
        public ActionResult CreatePlayer()
        {
            return View();
        }

        [HttpPost] //POST /Player/Create
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlayer(PlayerCreate playerCreateModel)
        {
            if (ModelState.IsValid)
            {
                if (_playerService.CreatePlayer(playerCreateModel))
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Player could not be created. Please check your inputs and try again.");
            return View(playerCreateModel);
        }


        [HttpGet] //GET: /Player/EditPlayerAttributes/{id}
        public ActionResult EditPlayerAttributes(int playerId)
        {
            return View();
        }
        public ActionResult EditPlayerAttributes(UpdatePlayerAttributes updatePlayerAttributesModel)
        {
            return View();
        }
    }
}