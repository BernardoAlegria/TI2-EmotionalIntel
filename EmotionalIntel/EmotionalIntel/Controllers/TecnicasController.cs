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
    public class TecnicasController : Controller
    {
        private readonly EmotionalDB _context;

        public TecnicasController(EmotionalDB context)
        {
            _context = context;
        }

        // GET: Tecnicas
        public async Task<IActionResult> Index()
        {
            var emotionalDB = _context.Tecnicas.Include(t => t.Teste);
            return View(await emotionalDB.ToListAsync());
        }

        public async Task<IActionResult> GestaoTempo()
        {
            var emotionalDB = _context.Tecnicas.Include(t => t.Teste);
            //    return View(await emotionalDB.ToListAsync());

            return View(emotionalDB);
        }
        public async Task<IActionResult> Empatia()
        {
            var emotionalDB = _context.Tecnicas.Include(t => t.Teste);
            //    return View(await emotionalDB.ToListAsync());

            return View(emotionalDB);
        }
        public async Task<IActionResult> GestaoStress()
        {
            var emotionalDB = _context.Tecnicas.Include(t => t.Teste);
            //    return View(await emotionalDB.ToListAsync());

            return View(emotionalDB);
        }
        public async Task<IActionResult> DesenvolvimentoEmocional()
        {
            var emotionalDB = _context.Tecnicas.Include(t => t.Teste);
            //    return View(await emotionalDB.ToListAsync());

            return View(emotionalDB);
        }
        public async Task<IActionResult> Coaching()
        {
            var emotionalDB = _context.Tecnicas.Include(t => t.Teste);
            //    return View(await emotionalDB.ToListAsync());

            return View(emotionalDB);
        }
        public async Task<IActionResult> InteligenciaEmocionalGlobal()
        {
            var emotionalDB = _context.Tecnicas.Include(t => t.Teste);
            //    return View(await emotionalDB.ToListAsync());

            return View(emotionalDB);
        }
        public async Task<IActionResult> GestaoConflitos()
        {
            var emotionalDB = _context.Tecnicas.Include(t => t.Teste);
            //    return View(await emotionalDB.ToListAsync());

            return View(emotionalDB);
        }
        public async Task<IActionResult> ExaustaoEmocional()
        {
            var emotionalDB = _context.Tecnicas.Include(t => t.Teste);
            //    return View(await emotionalDB.ToListAsync());

            return View(emotionalDB);
        }

        // GET: Tecnicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicas = await _context.Tecnicas
                .Include(t => t.Teste)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tecnicas == null)
            {
                return NotFound();
            }

            return View(tecnicas);
        }

        // GET: Tecnicas/Create
        public IActionResult Create()
        {
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome");
            return View();
        }

        // POST: Tecnicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nome,Descricao,Nivel,TesteFK")] Tecnicas tecnicas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnicas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome", tecnicas.TesteFK);
            return View(tecnicas);
        }

        // GET: Tecnicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicas = await _context.Tecnicas.FindAsync(id);
            if (tecnicas == null)
            {
                return NotFound();
            }
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome", tecnicas.TesteFK);
            return View(tecnicas);
        }

        // POST: Tecnicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nome,Descricao,Nivel,TesteFK")] Tecnicas tecnicas)
        {
            if (id != tecnicas.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnicas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnicasExists(tecnicas.ID))
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
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome", tecnicas.TesteFK);
            return View(tecnicas);
        }

        // GET: Tecnicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnicas = await _context.Tecnicas
                .Include(t => t.Teste)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tecnicas == null)
            {
                return NotFound();
            }

            return View(tecnicas);
        }

        // POST: Tecnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tecnicas = await _context.Tecnicas.FindAsync(id);
            _context.Tecnicas.Remove(tecnicas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnicasExists(int id)
        {
            return _context.Tecnicas.Any(e => e.ID == id);
        }
    }
}
