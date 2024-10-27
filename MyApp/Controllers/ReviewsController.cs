using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly MyDbContext _context;

        public ReviewsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var reviews = _context.Reviews.Include(r => r.User).Include(r => r.Product);
            return View(await reviews.ToListAsync());
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewBag.Users = new SelectList(_context.Users, "Id", "Username");
            ViewBag.Products = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = new SelectList(_context.Users, "Id", "Username", review.UserId);
            ViewBag.Products = new SelectList(_context.Products, "Id", "Name", review.ProductId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            ViewBag.Users = new SelectList(_context.Users, "Id", "Username", review.UserId);
            ViewBag.Products = new SelectList(_context.Products, "Id", "Name", review.ProductId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Users = new SelectList(_context.Users, "Id", "Username", review.UserId);
            ViewBag.Products = new SelectList(_context.Products, "Id", "Name", review.ProductId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews.Include(r => r.User).Include(r => r.Product).FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            // Проверяем, существует ли отзыв
            if (review == null)
            {
                return NotFound(); // Если отзыв не найден, возвращаем 404
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}