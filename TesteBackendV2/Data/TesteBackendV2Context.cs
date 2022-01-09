using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBackendV2.Models;

namespace TesteBackendV2.Data
{
    public class TesteBackendV2Context : DbContext
    {
        public TesteBackendV2Context (DbContextOptions<TesteBackendV2Context> options)
            : base(options)
        {
        }

        public DbSet<TesteBackendV2.Models.equipment> equipment { get; set; }

        public DbSet<TesteBackendV2.Models.equipment_model> equipment_model { get; set; }

        public DbSet<TesteBackendV2.Models.equipment_state> equipment_state { get; set; }

        public DbSet<TesteBackendV2.Models.equipment_model_state_hourly_earnings> equipment_model_state_hourly_earnings { get; set; }

        public DbSet<TesteBackendV2.Models.equipment_position_history> equipment_position_history { get; set; }

        public DbSet<TesteBackendV2.Models.equipment_state_history> equipment_state_history { get; set; }
    }
}
