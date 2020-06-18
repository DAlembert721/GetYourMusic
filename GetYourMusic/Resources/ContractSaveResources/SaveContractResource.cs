using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources
{
    public class SaveContractResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public float PaymentAmount { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Reference { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
