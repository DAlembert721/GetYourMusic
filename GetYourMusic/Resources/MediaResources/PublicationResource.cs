using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources
{
    public class PublicationResource
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string VideoUrl { get; set; }
        public string PublicationType { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
