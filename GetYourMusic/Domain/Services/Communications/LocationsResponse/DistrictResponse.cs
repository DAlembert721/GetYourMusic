using GetYourMusic.Domain.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class DistrictResponse: BaseResponse<District>
    {
        public DistrictResponse(string message) : base(message) { }

        public DistrictResponse(District district) : base(district) { }
    }
}
