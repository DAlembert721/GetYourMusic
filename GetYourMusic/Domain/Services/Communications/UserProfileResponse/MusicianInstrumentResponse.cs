using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class MusicianInstrumentResponse : BaseResponse<MusicianInstrument>
    {
        public MusicianInstrumentResponse(MusicianInstrument musicianInstrument) : base(musicianInstrument)
        {
        }

        public MusicianInstrumentResponse(string message) : base(message) { }
    }
}
