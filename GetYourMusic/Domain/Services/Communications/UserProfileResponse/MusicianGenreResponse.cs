using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class MusicianGenreResponse : BaseResponse<MusicianGenre>
    {
        public MusicianGenreResponse(MusicianGenre musicianGenre) : base(musicianGenre)
        {
        }

        public MusicianGenreResponse(string message) : base(message) { }
    }
}
