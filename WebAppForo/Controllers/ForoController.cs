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
    public class ForoController : Controller
    {
        private readonly WebAppDatabaseContext _context;

        public ForoController(WebAppDatabaseContext context)
        {
            _context = context;
        }

        // GET: Foro
        public async Task<IActionResult> Index()
        {
            var webAppDatabaseContext = _context.Mensajes.Include(m => m.User);
            return View(await webAppDatabaseContext.ToListAsync());
        }

        // GET: Foro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mensajes == null)
            {
                return NotFound();
            }

            var mensaje = await _context.Mensajes
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MsgId == id);
            if (mensaje == null)
            {
                return NotFound();
            }

            return View(mensaje);
        }

        // GET: Foro/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Usuarios, "UserId", "UserId");
            return View();
        }

        // POST: Foro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MsgId,Texto,Imagen,UserId")] Mensaje mensaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Usuarios, "UserId", "UserId", mensaje.UserId);
            return View(mensaje);
        }

        // GET: Foro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mensajes == null)
            {
                return NotFound();
            }

            var mensaje = await _context.Mensajes.FindAsync(id);
            if (mensaje == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Usuarios, "UserId", "UserId", mensaje.UserId);
            return View(mensaje);
        }

        // POST: Foro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MsgId,Texto,Imagen,UserId")] Mensaje mensaje)
        {
            if (id != mensaje.MsgId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensajeExists(mensaje.MsgId))
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
            ViewData["UserId"] = new SelectList(_context.Usuarios, "UserId", "UserId", mensaje.UserId);
            return View(mensaje);
        }

        // GET: Foro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mensajes == null)
            {
                return NotFound();
            }

            var mensaje = await _context.Mensajes
                .Include(m => m.User)
                .FirstOrDefaultAsync(m => m.MsgId == id);
            if (mensaje == null)
            {
                return NotFound();
            }

            return View(mensaje);
        }

        // POST: Foro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mensajes == null)
            {
                return Problem("Entity set 'WebAppDatabaseContext.Mensajes'  is null.");
            }
            var mensaje = await _context.Mensajes.FindAsync(id);
            if (mensaje != null)
            {
                _context.Mensajes.Remove(mensaje);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensajeExists(int id)
        {
          return (_context.Mensajes?.Any(e => e.MsgId == id)).GetValueOrDefault();
        }
    }
}
