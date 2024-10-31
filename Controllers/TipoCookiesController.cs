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
    public class TipoCookiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoCookiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoCookies
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoCookie.ToListAsync());
        }

        // GET: TipoCookies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCookie = await _context.TipoCookie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCookie == null)
            {
                return NotFound();
            }

            return View(tipoCookie);
        }

        // GET: TipoCookies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoCookies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sabor,Descricao")] TipoCookie tipoCookie)
        {
            if (ModelState.IsValid)
            {
                tipoCookie.Id = Guid.NewGuid();
                _context.Add(tipoCookie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoCookie);
        }

        // GET: TipoCookies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCookie = await _context.TipoCookie.FindAsync(id);
            if (tipoCookie == null)
            {
                return NotFound();
            }
            return View(tipoCookie);
        }

        // POST: TipoCookies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Sabor,Descricao")] TipoCookie tipoCookie)
        {
            if (id != tipoCookie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoCookie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoCookieExists(tipoCookie.Id))
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
            return View(tipoCookie);
        }

        // GET: TipoCookies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoCookie = await _context.TipoCookie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoCookie == null)
            {
                return NotFound();
            }

            return View(tipoCookie);
        }

        // POST: TipoCookies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tipoCookie = await _context.TipoCookie.FindAsync(id);
            if (tipoCookie != null)
            {
                _context.TipoCookie.Remove(tipoCookie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoCookieExists(Guid id)
        {
            return _context.TipoCookie.Any(e => e.Id == id);
        }
    }
}
