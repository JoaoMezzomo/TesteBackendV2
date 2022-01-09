using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesteBackendV2.Models
{
    public class equipment_model
    {
        [Key]
        public Guid id { get; set; }
        [Display(Name = "Nome do Modelo")]
        public string name { get; set; }
    }
}
