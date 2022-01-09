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
    public class equipment_model_state_hourly_earningsController : ControllerBase
    {
        private readonly TesteBackendV2APIContext _context;

        public equipment_model_state_hourly_earningsController(TesteBackendV2APIContext context)
        {
            _context = context;
        }

        // GET: api/equipment_model_state_hourly_earnings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<equipment_model_state_hourly_earnings>>> Getequipment_model_state_hourly_earnings()
        {
            return await _context.equipment_model_state_hourly_earnings.ToListAsync();
        }

        // POST: api/equipment_model_state_hourly_earnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<equipment_model_state_hourly_earnings>>> Postequipment_model_state_hourly_earnings(equipment_model_state_hourly_earnings equipment_model_state_hourly_earnings)
        {
            _context.equipment_model_state_hourly_earnings.Add(equipment_model_state_hourly_earnings);
            await _context.SaveChangesAsync();

            return await _context.equipment_model_state_hourly_earnings.ToListAsync();
        }
    }
}
