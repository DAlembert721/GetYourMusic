using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources
{
    public class SaveCommentResource
    {
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }
    }
}
