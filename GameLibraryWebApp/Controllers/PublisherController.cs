using GameLibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGameLibrary.Data;

namespace GameLibraryWebApp.Controllers
{
    public class PublisherController : Controller
    {
        private readonly GameContext _context;

        public PublisherController(GameContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var list = _context.Publishers
                        .Include(b => b.BoardGames)
                        .ToList();

            return View(list);
        }
        public ActionResult Details(int Id)
        {
            var list = _context.Publishers
                    .Where(b=> b.Id == Id)
                    .Include(b => b.BoardGames)
                    .FirstOrDefault();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PublisherModel publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Publishers.Add(publisher);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }
        public ActionResult AddGame(int id)
        {
            var game = new BoardGameModel();
            game.PublishersId = id;
            return View(game);
        }
        [HttpPost]
        public ActionResult AddGame(BoardGameModel boardGame)
        {
            if (ModelState.IsValid)
            {
                boardGame.PublishersId = boardGame.Id;
                boardGame.Id = 0;
                _context.BoardGames.Add(boardGame);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boardGame);
        }


    }
}
