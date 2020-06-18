using GetYourMusic.Domain.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class RegionResponse : BaseResponse<Region>
    {
        public RegionResponse(string message) : base(message) { }

        public RegionResponse(Region region) : base(region) { }
    }
}
