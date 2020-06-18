using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.Media_System
{
    public class Publication
    {
        public int Id { get; set; }
        public string MediaUrl { get; set; }
        public string Content { get; set; }
        public string PublicationType { get; set; }
        public DateTime UpdateTime { get; set; }
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
        public IList<Comment> Comments { get; set; } = new List<Comment>();
    }
}
