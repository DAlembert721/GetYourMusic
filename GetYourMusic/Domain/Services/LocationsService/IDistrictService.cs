using GetYourMusic.Domain.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IDistrictService
    {
        Task<IEnumerable<District>> ListByCityIdAsync(int cityId);
    }
}
