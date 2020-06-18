using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources.ContractSaveResources
{
    public class SaveQualificationResource
    {
        [Required]
        [MaxLength(30)]
        public string Text { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
