using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources
{
    public class SavePublicationResource
    {
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
        [Required]
        [MaxLength(255)]
        public string VideoUrl { get; set; }
    }
}
