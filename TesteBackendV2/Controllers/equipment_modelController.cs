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
    public class equipment_modelController : Controller
    {
        private readonly TesteBackendV2Context _context;

        public equipment_modelController(TesteBackendV2Context context)
        {
            _context = context;
        }

        // GET: equipment_model
        public async Task<IActionResult> Index()
        {
            return View(await _context.equipment_model.ToListAsync());
        }

        // GET: equipment_model/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: equipment_model/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] equipment_model equipment_model)
        {
            if (ModelState.IsValid)
            {
                equipment_model.id = Guid.NewGuid();
                _context.Add(equipment_model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment_model);
        }

        // GET: equipment_model/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment_model = await _context.equipment_model.FindAsync(id);
            if (equipment_model == null)
            {
                return NotFound();
            }
            return View(equipment_model);
        }

        // POST: equipment_model/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name")] equipment_model equipment_model)
        {
            if (id != equipment_model.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment_model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!equipment_modelExists(equipment_model.id))
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
            return View(equipment_model);
        }

        // GET: equipment_model/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment_model = await _context.equipment_model
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipment_model == null)
            {
                return NotFound();
            }

            return View(equipment_model);
        }

        // POST: equipment_model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var equipment_model = await _context.equipment_model.FindAsync(id);
            _context.equipment_model.Remove(equipment_model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool equipment_modelExists(Guid id)
        {
            return _context.equipment_model.Any(e => e.id == id);
        }
    }
}
