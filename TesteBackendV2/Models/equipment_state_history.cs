using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TesteBackendV2.Models
{
    [Keyless]
    public class equipment_state_history
    {
        public Guid equipment_id { get; set; }
        [Display(Name = "Data")]
        public DateTime date { get; set; }
        public Guid equipment_state_id { get; set; }
    }
}
