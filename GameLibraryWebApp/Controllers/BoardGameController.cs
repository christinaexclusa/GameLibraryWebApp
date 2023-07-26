﻿using GameLibraryWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyGameLibrary.Data;

namespace GameLibraryWebApp.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly GameContext _context;
        public BoardGameController(GameContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            return View(_context.BoardGames
                .Include(p => p.Publishers)
                .ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BoardGameModel boardGame)
        {
            if (ModelState.IsValid)
            {
                boardGame.PublishersId = GetPublisher(boardGame.NewPublisher);
                _context.BoardGames.Add(boardGame);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boardGame);
        }
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var game = _context.BoardGames.FirstOrDefault(
                g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }
        //the http get delete method doesn't delete the specified game, it returns a 
        //view of the game where you can submit the deletion
        [HttpPost]
        public ActionResult Delete(int? id, bool notUsed)
        {
            if (_context.BoardGames == null)
            {
                return Problem("Entity set 'GameContext.BoardGames is null");
            }
            var game = _context.BoardGames.Find(id);
            _context.BoardGames.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, BoardGameModel game)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(game).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }



        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var game = _context.BoardGames
                .Where(b => b.Id == id)
                .Include(b => b.Publishers)
                .FirstOrDefault();

            return View(game);
        }





        private int GetPublisher(string publisher)
        {
            PublisherModel? pub = null;
            pub = _context.Publishers
                .Where(p => p.Name.ToLower() == publisher.ToLower())
                .FirstOrDefault();
            if (pub == null)
            {
                pub = new PublisherModel { Name = publisher };
                _context.Add(pub);
                _context.SaveChanges();
            }
            return pub.Id;
        }
        private List<SelectListItem> PublisherList()
        {
            var list = _context.Publishers.ToList();
            List<SelectListItem> retValue = list.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return retValue;
        }
    }
}
