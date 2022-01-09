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
    public class equipment_model_state_hourly_earningsController : Controller
    {
        private readonly TesteBackendV2Context _context;

        public equipment_model_state_hourly_earningsController(TesteBackendV2Context context)
        {
            _context = context;
        }

        // GET: equipment_model_state_hourly_earnings
        public async Task<IActionResult> Index(Guid? equipment_model_id)
        {
            return View(await _context.equipment_model_state_hourly_earnings
                .Where(x => x.equipment_model_id == equipment_model_id)
                .ToListAsync());
        }

        // POST: equipment_model_state_hourly_earnings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("equipment_model_id,equipment_state_id,value")] equipment_model_state_hourly_earnings equipment_model_state_hourly_earnings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment_model_state_hourly_earnings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment_model_state_hourly_earnings);
        }
    }
}
