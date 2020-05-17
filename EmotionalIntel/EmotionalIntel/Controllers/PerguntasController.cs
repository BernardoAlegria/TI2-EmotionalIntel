using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmotionalIntel.Data;
using EmotionalIntel.Models;

namespace EmotionalIntel.Controllers
{
    public class PerguntasController : Controller
    {
        private readonly EmotionalDB _context;

        public PerguntasController(EmotionalDB context)
        {
            _context = context;
        }

        // GET: Perguntas
        public async Task<IActionResult> Index()
        {
            var emotionalDB = _context.Perguntas.Include(p => p.Testes);
            return View(await emotionalDB.ToListAsync());
        }

        // GET: Perguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perguntas = await _context.Perguntas
                .Include(p => p.Testes)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (perguntas == null)
            {
                return NotFound();
            }

            return View(perguntas);
        }

        // GET: Perguntas/Create
        public IActionResult Create()
        {
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome");
            return View();
        }

        // POST: Perguntas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TxtPergunta,TesteFK")] Perguntas perguntas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perguntas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome", perguntas.TesteFK);
            return View(perguntas);
        }

        // GET: Perguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perguntas = await _context.Perguntas.FindAsync(id);
            if (perguntas == null)
            {
                return NotFound();
            }
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome", perguntas.TesteFK);
            return View(perguntas);
        }

        // POST: Perguntas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TxtPergunta,TesteFK")] Perguntas perguntas)
        {
            if (id != perguntas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perguntas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerguntasExists(perguntas.ID))
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
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome", perguntas.TesteFK);
            return View(perguntas);
        }

        // GET: Perguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perguntas = await _context.Perguntas
                .Include(p => p.Testes)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (perguntas == null)
            {
                return NotFound();
            }

            return View(perguntas);
        }

        // POST: Perguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perguntas = await _context.Perguntas.FindAsync(id);
            _context.Perguntas.Remove(perguntas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerguntasExists(int id)
        {
            return _context.Perguntas.Any(e => e.ID == id);
        }
    }
}
