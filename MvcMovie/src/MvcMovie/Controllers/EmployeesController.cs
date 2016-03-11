using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Employees
        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }

        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employees employees = _context.Employees.Single(m => m.ID == id);
            if (employees == null)
            {
                return HttpNotFound();
            }

            return View(employees);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employees);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employees employees = _context.Employees.Single(m => m.ID == id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Update(employees);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }

        // GET: Employees/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Employees employees = _context.Employees.Single(m => m.ID == id);
            if (employees == null)
            {
                return HttpNotFound();
            }

            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Employees employees = _context.Employees.Single(m => m.ID == id);
            _context.Employees.Remove(employees);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
