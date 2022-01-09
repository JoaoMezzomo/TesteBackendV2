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
    public class equipment_stateController : Controller
    {
        private readonly TesteBackendV2Context _context;

        public equipment_stateController(TesteBackendV2Context context)
        {
            _context = context;
        }

        // GET: equipment_state
        public async Task<IActionResult> Index()
        {
            return View(await _context.equipment_state.ToListAsync());
        }

        // GET: equipment_state/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: equipment_state/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,color")] equipment_state equipment_state)
        {
            if (ModelState.IsValid)
            {
                equipment_state.id = Guid.NewGuid();
                _context.Add(equipment_state);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment_state);
        }

        // GET: equipment_state/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment_state = await _context.equipment_state.FindAsync(id);
            if (equipment_state == null)
            {
                return NotFound();
            }
            return View(equipment_state);
        }

        // POST: equipment_state/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,name,color")] equipment_state equipment_state)
        {
            if (id != equipment_state.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment_state);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!equipment_stateExists(equipment_state.id))
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
            return View(equipment_state);
        }

        // GET: equipment_state/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment_state = await _context.equipment_state
                .FirstOrDefaultAsync(m => m.id == id);
            if (equipment_state == null)
            {
                return NotFound();
            }

            return View(equipment_state);
        }

        // POST: equipment_state/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var equipment_state = await _context.equipment_state.FindAsync(id);
            _context.equipment_state.Remove(equipment_state);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool equipment_stateExists(Guid id)
        {
            return _context.equipment_state.Any(e => e.id == id);
        }
    }
}
