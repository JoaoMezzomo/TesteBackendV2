using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBackendV2.Models
{
    public class equipment_state
    {
        [Key]
        public Guid id { get; set; }
        [Display(Name = "Nome do Estado")]
        public string name { get; set; }
        [Display(Name = "Cor do Estado")]
        public string color { get; set; }
    }
}
