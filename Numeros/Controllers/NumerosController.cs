using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Numeros;
using Numeros.Models;

namespace Numeros.Controllers
{
    public class NumerosController : Controller
    {
        private readonly NumerosContext _context;

        public NumerosController(NumerosContext context)
        {
            _context = context;
        }

        // GET: Numeros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Numeros.OrderBy(x => x.Valor).ToListAsync());
        }

        // GET: Numeros/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numero = await _context.Numeros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (numero == null)
            {
                return NotFound();
            }

            return View(numero);
        }

        // GET: Numeros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Numeros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,Ordinal,Cardinal,Romanos")] Numero numero)
        {
            if (ModelState.IsValid)
            {
                numero.Id = Guid.NewGuid();
                _context.Add(numero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(numero);
        }

        // GET: Numeros/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numero = await _context.Numeros.FindAsync(id);
            if (numero == null)
            {
                return NotFound();
            }
            return View(numero);
        }

        // POST: Numeros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Valor,Ordinal,Cardinal,Romanos")] Numero numero)
        {
            if (id != numero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(numero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NumeroExists(numero.Id))
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
            return View(numero);
        }

        // GET: Numeros/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var numero = await _context.Numeros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (numero == null)
            {
                return NotFound();
            }

            return View(numero);
        }

        // POST: Numeros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var numero = await _context.Numeros.FindAsync(id);
            _context.Numeros.Remove(numero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NumeroExists(Guid id)
        {
            return _context.Numeros.Any(e => e.Id == id);
        }
    }
}
