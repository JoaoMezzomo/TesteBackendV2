using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TesteBackendV2.Data;
using TesteBackendV2.Models;

namespace TesteBackendV2.Controllers
{
    public class equipmentsController : Controller
    {
        private readonly TesteBackendV2Context _context;

        public equipmentsController(TesteBackendV2Context context)
        {
            _context = context;
        }

        // GET: equipments
        public async Task<IActionResult> Index()
        {
            return View(await _context.equipment.ToListAsync());
        }

        // GET: equipments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,equipment_model_id,name")] equipment equipment)
        {
            if (ModelState.IsValid)
            {
                equipment.id = Guid.NewGuid();
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        // GET: equipments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }

        // POST: equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,equipment_model_id,name")] equipment equipment)
        {
            if (id != equipment.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!equipmentExists(equipment.id))
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
            return View(equipment);
        }

        // GET: equipments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.equipment
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var equipment = await _context.equipment.FindAsync(id);
            _context.equipment.Remove(equipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool equipmentExists(Guid id)
        {
            return _context.equipment.Any(e => e.id == id);
        }
    }
}
