using System;
using System.ComponentModel.DataAnnotations;

namespace TesteBackendV2.Models
{
    public class equipment
    {
        [Key]
        public Guid id { get; set; }
        public Guid equipment_model_id { get; set; }
        [Display(Name = "Nome do Equipamento")]
        public string name { get; set; }   
    }
}
