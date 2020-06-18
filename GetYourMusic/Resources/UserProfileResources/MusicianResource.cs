using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources
{
    public class MusicianResource : AccountResource
    {
        public string Description { get; set; }
        public float Rating { get; set; }
    }
}
