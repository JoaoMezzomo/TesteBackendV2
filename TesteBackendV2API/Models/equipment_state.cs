using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBackendV2API.Models
{
    public class equipment_state
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
    }
}
