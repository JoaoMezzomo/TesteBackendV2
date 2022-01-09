using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteBackendV2API.Models
{
    public class equipment_model
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
    }
}
