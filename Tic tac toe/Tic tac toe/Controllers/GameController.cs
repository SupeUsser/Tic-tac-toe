using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tic_tac_toe.Models;
using Tic_tac_toe.ViewModels;

namespace Tic_tac_toe.Controllers
{
    public class GameController : Controller
    {
        public ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult Index(Guid id )
        {

            {
                var game = _db.Games.FirstOrDefault(i => i.Id == id);
            }


            return View();
        }
        // GET: Brand

        public ActionResult Create(string id)
        {
            if (ModelState.IsValid)
            {
               
                var newgame = new Game()
                {
                    Id = Guid.NewGuid(),
                    Grid = new string ('_', 9),
                    Player2Id= id,
                   Player1Id = _db.Users.FirstOrDefault(u =>u.UserName == User.Identity.Name).Id
                };
                _db.Games.Add(newgame);
                _db.SaveChanges();
                return RedirectToAction("Index", new { Id = newgame.Id });
            }
            return View();
        }
        public ActionResult Step(int cellNum,Guid gameId)
        {
            var game = _db.Games.FirstOrDefault(i => i.Id == gameId);
            var UserId = _db.Users.FirstOrDefault(u => u.UserName == User.Identity.Name).Id;
            if (game.Steps % 2 == 1)
            {
                game.Grid = game.Grid.Remove(cellNum);
                game.Grid = game.Grid.Insert(cellNum, "X);
                
                    }
        }
         
    }

}