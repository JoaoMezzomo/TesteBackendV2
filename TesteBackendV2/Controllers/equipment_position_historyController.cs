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
    public class equipment_position_historyController : Controller
    {
        private readonly TesteBackendV2Context _context;

        public equipment_position_historyController(TesteBackendV2Context context)
        {
            _context = context;
        }

        // GET: equipment_position_history
        public async Task<IActionResult> Index(Guid? equipment_id)
        {
            return View(await _context.equipment_position_history
                .Where(x => x.equipment_id == equipment_id)
                .OrderByDescending(x => x.date)
                .ToListAsync());
        }

        // POST: equipment_position_history/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("equipment_id,date,lat,lon")] equipment_position_history equipment_position_history)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment_position_history);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment_position_history);
        }
    }
}
