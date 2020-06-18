using GetYourMusic.Domain.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class CityResponse : BaseResponse<City>
    {
        public CityResponse(string message) : base(message) { }

        public CityResponse(City city) : base(city) { }
    }
}
