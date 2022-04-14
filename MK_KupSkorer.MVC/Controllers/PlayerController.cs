using MK_KupSkorer.Contracts;
using MK_KupSkorer.Models.PlayerModels;
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
            var playerDetail = _playerService.GetPlayerById(playerId);
            var model = new UpdatePlayerAttributes
            {
                PlayerId = playerDetail.PlayerId,
                FirstName = playerDetail.FirstName,
                LastName = playerDetail.LastName,
                Nickname = playerDetail.Nickname
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPlayerAttributes(UpdatePlayerAttributes updatePlayerAttributesModel)
        {
            if (ModelState.IsValid)
            {
                var playerToUpdate = _playerService.GetPlayerById(updatePlayerAttributesModel.PlayerId);

                if (_playerService.UpdatePlayerAttributes(updatePlayerAttributesModel, updatePlayerAttributesModel.PlayerId))
                {
                    return RedirectToAction("Index", "Player");

                }
            }

            ModelState.AddModelError("", "Player could not be edited. Please check your inputs and try again.");
            return View(updatePlayerAttributesModel);

        }


        [HttpPost] //POST: /player/delete/{id}
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int playerId)
        {

            if(_playerService.DeletePlayerById(playerId))
            return RedirectToAction("Index", "Player");

            ModelState.AddModelError("", "Player could not be deleted. Please check your inputs and try again.");
            return RedirectToAction("Index", "Player");


        }
    }
}