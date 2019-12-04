using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Incremental_Age.Models;
using Incremental_Age.Enteties;

namespace Incremental_Age.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Town()
        {
            GameModel gameModel = new GameModel();

            if (SharedGameRepo.Players.Count == 0 || SharedGameRepo.Players.Exists(x => x.Name != User.Identity.Name))
            {
                SharedGameRepo.Players.Add(new Player
                {
                    Name = User.Identity.Name
                });

            }
            SharedGameRepo.Trees.Add(new Tree
            {
                HP = 30
            });
            SharedGameRepo.Trees.Add(new Tree
            {
                HP = 40,
                X = 100,
                Y = 100
            });
            SharedGameRepo.Trees.Add(new Tree
            {
                HP = 20,
                X = 300,
                Y = 500
            });

            gameModel.Trees = SharedGameRepo.Trees.ToArray();
            gameModel.Players = SharedGameRepo.Players.ToArray();

            return View(gameModel);
        }

        public IActionResult AssignJob(string Job)
        {
            GameModel gameModel = new GameModel();

            Player player = SharedGameRepo.Players.Find(x => x.Name == User.Identity.Name);
            player.Job = Job;
            player.Action = "onRoute";

            gameModel.Players = SharedGameRepo.Players.ToArray();
            gameModel.Trees = SharedGameRepo.Trees.ToArray();

            return View("Town", gameModel);
        }

        public IActionResult ActionComplete(string playerName)
        {
            GameModel gameModel = new GameModel();

            Player player = SharedGameRepo.Players.Find(x => x.Name == playerName);

            switch (player.Action)
            {
                case "onRoute":
                    player.X = player.DestinationX;
                    player.Y = player.DestinationY;
                    player.Action = player.Job;
                    break;
                case "ChopTree":
                    player.Action = "onRoute";
                    player.DestinationX = 100;
                    player.DestinationY = 100;
                    break;
                default:
                    break;
            }

            gameModel.Players = SharedGameRepo.Players.ToArray();
            gameModel.Trees = SharedGameRepo.Trees.ToArray();
            return View("Town", gameModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
