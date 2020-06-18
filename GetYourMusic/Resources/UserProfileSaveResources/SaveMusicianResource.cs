using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources
{
    public class SaveMusicianResource : SaveAccountResource
    {
        public string Description { get; set; }
        public float Rating { get; set; }
    }
}
