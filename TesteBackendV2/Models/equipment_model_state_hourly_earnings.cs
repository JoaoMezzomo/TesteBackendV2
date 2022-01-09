using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TesteBackendV2.Models
{
    [Keyless]
    public class equipment_model_state_hourly_earnings
    {
        public Guid equipment_model_id { get; set; }
        public Guid equipment_state_id { get; set; }
        public double value { get; set; }
    }
}
