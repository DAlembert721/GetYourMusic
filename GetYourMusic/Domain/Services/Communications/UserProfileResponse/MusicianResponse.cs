using GetYourMusic.Domain.Models;

namespace GetYourMusic.Domain.Services.Communications
{
    public class MusicianResponse : BaseResponse<Musician>
    {
        public MusicianResponse(string message) : base(message) { }

        public MusicianResponse(Musician musician) : base(musician) { }
    }
}
