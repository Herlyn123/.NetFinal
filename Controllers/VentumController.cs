using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerFinal.Data;
using TallerFinal.Models;
using TallerFinal.Models.ViewModels;

namespace TallerFinal.Controllers
{
    public class VentumController : Controller
    {
        private readonly Data.DBentregaFinalContext _context;

        public VentumController(DBentregaFinalContext context)
        {
            _context = context;
        }

        // GET: Ventum
        public async Task<IActionResult> Index()
        {
            var Venta = _context.Venta.Include(v => v.Cliente);
            return View(await Venta.ToListAsync());
        }

        // GET: Ventum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }


            var venta = _context.Venta.FirstOrDefault(v => v.VentaId == id);

            if (venta == null)
                return NotFound();

            var clientes = _context.Clientes.ToList();

            var viewModel = new VentasViewModels
            {
                VentaId = venta.VentaId,
                OpcionesDeClientes = clientes.Select(cliente => new SelectListItem
                {
                    Value = cliente.ClienteId.ToString(),
                    Text = cliente.Nombre
                }).ToList()
            };
            return View(viewModel);
        }

        // GET: Ventum/Create
        public IActionResult Create()
        {
            var clientesConEstadoTrue = _context.Clientes.Where(c => c.Estado == true).ToList();
            ViewData["ClienteId"] = new SelectList(clientesConEstadoTrue, "ClienteId", "ClienteId");
            return View();
        }

        // POST: Ventum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaId,Fecha,PrecioTotal,Producto,Estado,ClienteId")] Ventum ventum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nombre", ventum.ClienteId);
            return View(ventum);
        }

        // GET: Ventum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }


            var venta = _context.Venta.FirstOrDefault(v => v.VentaId == id);

            Console.WriteLine(venta);

            if (venta == null)
                return NotFound();

            var clientes = _context.Clientes.ToList();

            var viewModel = new VentasViewModels
            {
                VentaId = venta.VentaId,
                Fecha = venta.Fecha,
                PrecioTotal = venta.PrecioTotal,
                Producto = venta.Producto,
                Estado = venta.Estado,
                OpcionesDeClientes = clientes.Select(cliente => new SelectListItem
                {
                    Value = cliente.ClienteId.ToString(),
                    Text = cliente.Nombre
                }).ToList()
            };
            return View(viewModel);
        }

        // POST: Ventum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaId,Fecha,PrecioTotal,Producto,Estado,ClienteId")] VentasViewModels ventum)
        {
            if (id != ventum.VentaId)
            {
                return NotFound();
            }


            try
            {
                // Recupera la entidad de venta desde la base de datos
                var venta = await _context.Venta.FirstOrDefaultAsync(v => v.VentaId == id);

                if (venta == null)
                {
                    return NotFound();
                }

                // Actualiza la entidad de venta con los datos del modelo de vista
                venta.VentaId = ventum.VentaId;
                venta.Fecha = ventum.Fecha;
                venta.PrecioTotal = ventum.PrecioTotal;
                venta.Producto = ventum.Producto;
                venta.Estado = ventum.Estado;

                venta.ClienteId = ventum.ClienteId;

                // Guarda los cambios en la base de datos
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentumExists(ventum.VentaId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // GET: Ventum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = _context.Venta.Find(id);

            if (venta == null)
            {
                return NotFound();
            }

            // Realiza la eliminación del registro

            venta.Estado = !venta.Estado;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index"); // Redirecciona a la acción Index u otra acción que desees después de la eliminación.
        }

        private bool VentumExists(int id)
        {
            return (_context.Venta?.Any(e => e.VentaId == id)).GetValueOrDefault();
        }
    }
}
