using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TesteBackendV2.Models
{
    [Keyless]
    public class equipment_position_history
    {
        public Guid equipment_id { get; set; }
        public DateTime date { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
    }
}
