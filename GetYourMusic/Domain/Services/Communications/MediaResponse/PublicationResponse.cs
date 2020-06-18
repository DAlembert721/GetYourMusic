using GetYourMusic.Domain.Models.Media_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class PublicationResponse : BaseResponse<Publication>
    {
        public PublicationResponse(string message) : base(message) { }

        public PublicationResponse(Publication publication) : base(publication) { }
    }
}
