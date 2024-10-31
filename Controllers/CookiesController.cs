using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CookieOtavio.Data;
using LocadoraMVC.Models;

namespace CookieOtavio.Controllers
{
    public class CookiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CookiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cookies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cookie.Include(c => c.Estoque);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cookies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookie = await _context.Cookie
                .Include(c => c.Estoque)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookie == null)
            {
                return NotFound();
            }

            return View(cookie);
        }

        // GET: Cookies/Create
        public IActionResult Create()
        {
            ViewData["EstoqueId"] = new SelectList(_context.Set<Estoque>(), "Id", "Nome");
            return View();
        }

        // POST: Cookies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco,EstoqueId")] Cookie cookie)
        {
            if (ModelState.IsValid)
            {
                cookie.Id = Guid.NewGuid();
                _context.Add(cookie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstoqueId"] = new SelectList(_context.Set<Estoque>(), "Id", "Nome", cookie.EstoqueId);
            return View(cookie);
        }

        // GET: Cookies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookie = await _context.Cookie.FindAsync(id);
            if (cookie == null)
            {
                return NotFound();
            }
            ViewData["EstoqueId"] = new SelectList(_context.Set<Estoque>(), "Id", "Nome", cookie.EstoqueId);
            return View(cookie);
        }

        // POST: Cookies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nome,Preco,EstoqueId")] Cookie cookie)
        {
            if (id != cookie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cookie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CookieExists(cookie.Id))
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
            ViewData["EstoqueId"] = new SelectList(_context.Set<Estoque>(), "Id", "Nome", cookie.EstoqueId);
            return View(cookie);
        }

        // GET: Cookies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cookie = await _context.Cookie
                .Include(c => c.Estoque)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cookie == null)
            {
                return NotFound();
            }

            return View(cookie);
        }

        // POST: Cookies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cookie = await _context.Cookie.FindAsync(id);
            if (cookie != null)
            {
                _context.Cookie.Remove(cookie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CookieExists(Guid id)
        {
            return _context.Cookie.Any(e => e.Id == id);
        }
    }
}
