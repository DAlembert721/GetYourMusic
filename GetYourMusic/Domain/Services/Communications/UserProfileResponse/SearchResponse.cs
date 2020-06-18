using GetYourMusic.Domain.Models.UserProfileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class SearchResponse : BaseResponse<Search>
    {
        public SearchResponse(Search resource) : base(resource)
        {
        }

        public SearchResponse(string message) : base(message)
        {
        }
    }
}
