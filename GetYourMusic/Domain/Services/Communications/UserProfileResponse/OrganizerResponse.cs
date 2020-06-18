using GetYourMusic.Domain.Models;

namespace GetYourMusic.Domain.Services.Communications
{
    public class OrganizerResponse : BaseResponse<Organizer>
    {
        public OrganizerResponse(string message) : base(message) { }

        public OrganizerResponse(Organizer organizer) : base(organizer) { }
    }
}
