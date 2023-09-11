﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerFinal.Data;
using TallerFinal.Models;

namespace TallerFinal.Controllers
{
    public class ProveedorsController : Controller
    {
        private readonly DBentregaFinalContext _context;

        public ProveedorsController(DBentregaFinalContext context)
        {
            _context = context;
        }

        // GET: Proveedors
        public async Task<IActionResult> Index()
        {
            return _context.Proveedors != null ?
                        View(await _context.Proveedors.ToListAsync()) :
                        Problem("Entity set 'DBentregaFinalContext.Proveedors'  is null.");
        }

        // GET: Proveedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proveedors == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedors
                .FirstOrDefaultAsync(m => m.ProveedorId == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return View(proveedor);
        }

        // GET: Proveedors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proveedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProveedorId,Nombre,Telefono,Direccion,Contacto,Estado")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }

        // GET: Proveedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proveedors == null)
            {
                return NotFound();
            }

            var proveedor = await _context.Proveedors.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProveedorId,Nombre,Telefono,Direccion,Contacto,Estado")] Proveedor proveedor)
        {
            if (id != proveedor.ProveedorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proveedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProveedorExists(proveedor.ProveedorId))
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
            return View(proveedor);
        }

        // GET: Ventum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proveedo = _context.Proveedors.Find(id);

            if (proveedo == null)
            {
                return NotFound();
            }

            // Realiza la eliminación del registro

            proveedo.Estado = !proveedo.Estado;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // Redirecciona a la acción Index u otra acción que desees después de la eliminación.
        }

        private bool ProveedorExists(int id)
        {
            return (_context.Proveedors?.Any(e => e.ProveedorId == id)).GetValueOrDefault();
        }
    }
}
