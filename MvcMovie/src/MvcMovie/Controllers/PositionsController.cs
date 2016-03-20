using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class PositionsController : Controller
    {
        private ApplicationDbContext _context;

        public PositionsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Positions
        public IActionResult Index()
        {
            return View(_context.Positions.ToList());
        }

        // GET: Positions/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Positions positions = _context.Positions.Single(m => m.ID == id);
            if (positions == null)
            {
                return HttpNotFound();
            }

            return View(positions);
        }

        // GET: Positions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Positions positions)
        {
            if (ModelState.IsValid)
            {
                _context.Positions.Add(positions);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(positions);
        }

        // GET: Positions/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Positions positions = _context.Positions.Single(m => m.ID == id);
            if (positions == null)
            {
                return HttpNotFound();
            }
            return View(positions);
        }

        // POST: Positions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Positions positions)
        {
            if (ModelState.IsValid)
            {
                _context.Update(positions);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(positions);
        }

        // GET: Positions/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Positions positions = _context.Positions.Single(m => m.ID == id);
            if (positions == null)
            {
                return HttpNotFound();
            }

            return View(positions);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Positions positions = _context.Positions.Single(m => m.ID == id);
            _context.Positions.Remove(positions);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
