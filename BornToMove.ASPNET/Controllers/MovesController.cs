using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BornToMove.DAL;
using BornToMove.Business;

namespace BornToMove.ASPNET.Controllers
{
    public class MovesController : Controller
    {
        private readonly BuMove _buMove;

        public MovesController(BuMove buMove)
        {
            _buMove = buMove;
        }

        // GET: Moves
        public async Task<IActionResult> Index()
        {
              List<MoveRating> allMoves = _buMove.GetAllMoves();
              return View(allMoves);
        }

        // GET: Moves/Details/5
        public IActionResult Details(int id, string? returnPath)
        {
            System.Console.WriteLine($"return path = {returnPath}");
            if (id == null)
            {
                return NotFound();
            }

            var move = _buMove.GetMoveById(id);
            if (move == null)
            {
                return NotFound();
            }
            ViewData["returnPath"] = returnPath?? "Home";
            return View(move);
        }

        public async Task<IActionResult> Random()
        {
            var move = _buMove.GetRandomMove();
            if (move == null)
            {
                return NotFound();
            }
            return View("Details", move);
        }

    }
}
