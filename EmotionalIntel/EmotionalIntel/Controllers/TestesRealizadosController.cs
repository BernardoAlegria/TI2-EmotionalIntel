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
    public class TestesRealizadosController : Controller
    {
        private readonly EmotionalDB _context;

        public TestesRealizadosController(EmotionalDB context)
        {
            _context = context;
        }

        // GET: TestesRealizados
        public async Task<IActionResult> FazerTeste()
        {
            var emotionalDB = _context.Testes_Realizados.Include(t => t.Teste).Include(t => t.Utilizador);
            //    return View(await emotionalDB.ToListAsync());

            return View(emotionalDB); 
        }

        // GET: TestesRealizados
        public async Task<IActionResult> Index()
        {
            var emotionalDB = _context.Testes_Realizados.Include(t => t.Teste).Include(t => t.Utilizador);
            return View(await emotionalDB.ToListAsync());
        }

        // GET: TestesRealizados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testesRealizados = await _context.Testes_Realizados
                .Include(t => t.Teste)
                .Include(t => t.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (testesRealizados == null)
            {
                return NotFound();
            }

            return View(testesRealizados);
        }

        // GET: TestesRealizados/Create
        public IActionResult Create()
        {
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome");
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Nome");
            return View();
        }

        // POST: TestesRealizados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Pontuacao,Data,UtilizadorFK,TesteFK")] TestesRealizados testesRealizados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testesRealizados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome", testesRealizados.TesteFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Nome", testesRealizados.UtilizadorFK);
            return View(testesRealizados);
        }

        // GET: TestesRealizados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testesRealizados = await _context.Testes_Realizados.FindAsync(id);
            if (testesRealizados == null)
            {
                return NotFound();
            }
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome", testesRealizados.TesteFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Nome", testesRealizados.UtilizadorFK);
            return View(testesRealizados);
        }

        // POST: TestesRealizados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Pontuacao,Data,UtilizadorFK,TesteFK")] TestesRealizados testesRealizados)
        {
            if (id != testesRealizados.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testesRealizados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestesRealizadosExists(testesRealizados.ID))
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
            ViewData["TesteFK"] = new SelectList(_context.Testes, "ID", "Nome", testesRealizados.TesteFK);
            ViewData["UtilizadorFK"] = new SelectList(_context.Utilizadores, "ID", "Nome", testesRealizados.UtilizadorFK);
            return View(testesRealizados);
        }

        // GET: TestesRealizados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testesRealizados = await _context.Testes_Realizados
                .Include(t => t.Teste)
                .Include(t => t.Utilizador)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (testesRealizados == null)
            {
                return NotFound();
            }

            return View(testesRealizados);
        }

        // POST: TestesRealizados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testesRealizados = await _context.Testes_Realizados.FindAsync(id);
            _context.Testes_Realizados.Remove(testesRealizados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestesRealizadosExists(int id)
        {
            return _context.Testes_Realizados.Any(e => e.ID == id);
        }
    }
}
