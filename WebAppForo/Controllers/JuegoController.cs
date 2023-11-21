using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppForo.Context;
using WebAppForo.Models;

namespace WebAppForo.Controllers
{
    public class JuegoController : Controller
    {
        private readonly WebAppDatabaseContext _context;

        public JuegoController(WebAppDatabaseContext context)
        {
            _context = context;
        }

        // GET: Juego
        public async Task<IActionResult> Index()
        {
              return _context.Juegos != null ? 
                          View(await _context.Juegos.ToListAsync()) :
                          Problem("Entity set 'WebAppDatabaseContext.Juegos'  is null.");
        }

        // GET: Juego/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Juegos == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos
                .FirstOrDefaultAsync(m => m.JuegoId == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        // GET: Juego/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juego/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JuegoId,NombreJuego,DescJuego,ImgJuego,Posicion")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(juego);
        }

        // GET: Juego/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Juegos == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos.FindAsync(id);
            if (juego == null)
            {
                return NotFound();
            }
            return View(juego);
        }

        // POST: Juego/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JuegoId,NombreJuego,DescJuego,ImgJuego,Posicion")] Juego juego)
        {
            if (id != juego.JuegoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuegoExists(juego.JuegoId))
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
            return View(juego);
        }

        // GET: Juego/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Juegos == null)
            {
                return NotFound();
            }

            var juego = await _context.Juegos
                .FirstOrDefaultAsync(m => m.JuegoId == id);
            if (juego == null)
            {
                return NotFound();
            }

            return View(juego);
        }

        // POST: Juego/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Juegos == null)
            {
                return Problem("Entity set 'WebAppDatabaseContext.Juegos'  is null.");
            }
            var juego = await _context.Juegos.FindAsync(id);
            if (juego != null)
            {
                _context.Juegos.Remove(juego);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuegoExists(int id)
        {
          return (_context.Juegos?.Any(e => e.JuegoId == id)).GetValueOrDefault();
        }
    }
}
