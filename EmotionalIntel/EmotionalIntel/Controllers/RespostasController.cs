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
    public class RespostasController : Controller
    {
        private readonly EmotionalDB _context;

        public RespostasController(EmotionalDB context)
        {
            _context = context;
        }

        // GET: Respostas
        public async Task<IActionResult> Index()
        {
            var emotionalDB = _context.Respostas.Include(r => r.Perguntas);
            return View(await emotionalDB.ToListAsync());
        }

        // GET: Respostas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostas = await _context.Respostas
                .Include(r => r.Perguntas)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (respostas == null)
            {
                return NotFound();
            }

            return View(respostas);
        }

        // GET: Respostas/Create
        public IActionResult Create()
        {
            ViewData["PerguntaFK"] = new SelectList(_context.Perguntas, "ID", "TxtPergunta");
            return View();
        }

        // POST: Respostas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TxtRespostas,PerguntaFK")] Respostas respostas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(respostas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PerguntaFK"] = new SelectList(_context.Perguntas, "ID", "TxtPergunta", respostas.PerguntaFK);
            return View(respostas);
        }

        // GET: Respostas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostas = await _context.Respostas.FindAsync(id);
            if (respostas == null)
            {
                return NotFound();
            }
            ViewData["PerguntaFK"] = new SelectList(_context.Perguntas, "ID", "TxtPergunta", respostas.PerguntaFK);
            return View(respostas);
        }

        // POST: Respostas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TxtRespostas,PerguntaFK")] Respostas respostas)
        {
            if (id != respostas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(respostas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RespostasExists(respostas.ID))
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
            ViewData["PerguntaFK"] = new SelectList(_context.Perguntas, "ID", "TxtPergunta", respostas.PerguntaFK);
            return View(respostas);
        }

        // GET: Respostas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var respostas = await _context.Respostas
                .Include(r => r.Perguntas)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (respostas == null)
            {
                return NotFound();
            }

            return View(respostas);
        }

        // POST: Respostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var respostas = await _context.Respostas.FindAsync(id);
            _context.Respostas.Remove(respostas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RespostasExists(int id)
        {
            return _context.Respostas.Any(e => e.ID == id);
        }
    }
}
