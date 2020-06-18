using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.Media_System
{
    public class MusicianInstrument
    {
        public int MusicianId { get; set; }
        public Musician Musician { get; set; }
        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
    }
}
