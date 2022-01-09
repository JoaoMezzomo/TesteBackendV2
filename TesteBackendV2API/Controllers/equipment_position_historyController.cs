using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteBackendV2API.Data;
using TesteBackendV2API.Models;

namespace TesteBackendV2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class equipment_position_historyController : ControllerBase
    {
        private readonly TesteBackendV2APIContext _context;

        public equipment_position_historyController(TesteBackendV2APIContext context)
        {
            _context = context;
        }

        // GET: api/equipment_position_history
        [HttpGet]
        public async Task<ActionResult<IEnumerable<equipment_position_history>>> Getequipment_position_history()
        {
            return await _context.equipment_position_history.ToListAsync();
        }

        // POST: api/equipment_position_history
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<equipment_position_history>>> Postequipment_position_history(equipment_position_history equipment_position_history)
        {
            _context.equipment_position_history.Add(equipment_position_history);
            await _context.SaveChangesAsync();

            return await _context.equipment_position_history.ToListAsync();
        }
    }
}
