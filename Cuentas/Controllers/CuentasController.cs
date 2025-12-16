using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cuentas.Data;
using Cuentas.Models;

namespace Cuentas.Controllers
{
    public class CuentasController : Controller
    {
        private readonly CuentasContext _context;

        public CuentasController(CuentasContext context)
        {
            _context = context;
        }

        // GET: Cuentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cuenta.ToListAsync());
        }

        // GET: Cuentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuenta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return View(cuenta);
        }

        // GET: Cuentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,numero,descripcion,creditos,debitos,balance")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                cuenta.balance = cuenta.creditos - cuenta.debitos;
                _context.Add(cuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuenta);
        }

        // GET: Cuentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuenta.FindAsync(id);

            if (cuenta == null)
            {
                return NotFound();
            }

            if (cuenta.balance <= 0) // o cuenta.Estado == "Inactivo"
            {
                TempData["Error"] = "No se puede editar una cuenta inactiva.";
                return RedirectToAction("Index");
            }

            return View(cuenta);
        }


        // POST: Cuentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("descripcion")] Cuenta cuentaForm)
        {
            var cuentaDb = await _context.Cuenta.FindAsync(id);
            if (cuentaDb == null)
            {
                return NotFound();
            }
         
            if (cuentaDb.Estado == "Inactivo" || cuentaDb.balance <= 0)
            {
                TempData["Error"] = "No se puede editar una cuenta inactiva.";
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                return View(cuentaDb); 
            }

            cuentaDb.descripcion = cuentaForm.descripcion;

            _context.Update(cuentaDb);
            await _context.SaveChangesAsync();

            TempData["Success"] = "La descripción de la cuenta se actualizó correctamente.";
            return RedirectToAction(nameof(Index));
        }

        // GET: Cuentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuenta
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return View(cuenta);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuenta = await _context.Cuenta.FindAsync(id);
            if (cuenta != null)
            {
                _context.Cuenta.Remove(cuenta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuentaExists(int id)
        {
            return _context.Cuenta.Any(e => e.Id == id);
        }
    }
}
