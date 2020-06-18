using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.Media_System
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MusicianGenre> MusicianGenres { get; set; }
    }
}
