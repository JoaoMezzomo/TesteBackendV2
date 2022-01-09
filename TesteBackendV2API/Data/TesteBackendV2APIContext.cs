using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBackendV2API.Models;

namespace TesteBackendV2API.Data
{
    public class TesteBackendV2APIContext : DbContext
    {
        public TesteBackendV2APIContext (DbContextOptions<TesteBackendV2APIContext> options)
            : base(options)
        {
        }

        public DbSet<TesteBackendV2API.Models.equipment> equipment { get; set; }

        public DbSet<TesteBackendV2API.Models.equipment_model> equipment_model { get; set; }

        public DbSet<TesteBackendV2API.Models.equipment_state> equipment_state { get; set; }

        public DbSet<TesteBackendV2API.Models.equipment_model_state_hourly_earnings> equipment_model_state_hourly_earnings { get; set; }

        public DbSet<TesteBackendV2API.Models.equipment_position_history> equipment_position_history { get; set; }

        public DbSet<TesteBackendV2API.Models.equipment_state_history> equipment_state_history { get; set; }
    }
}
