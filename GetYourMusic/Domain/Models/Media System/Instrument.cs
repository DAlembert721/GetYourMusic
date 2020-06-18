using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.Media_System
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MusicianInstrument> MusicianInstruments { get; set; }
    }
}
