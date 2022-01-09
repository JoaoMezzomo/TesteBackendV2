using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBackendV2API.Models
{
    public class equipment
    {
        [Key]
        public Guid id { get; set; }
        public Guid equipment_model_id { get; set; }
        public string name { get; set; }   
    }
}
