using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources
{
    public class SaveSearchResource
    {
        [MaxLength(50)]
        public string Content { get; set; }
        public int Genre { get; set; }
        public int Instrument { get; set; }
        public int District { get; set; }
    }
}
