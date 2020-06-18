using GetYourMusic.Domain.Models.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IDistrictRepository
    {
        Task<IEnumerable<District>> ListByCityIdAsync(int cityId);
        Task<District> FindById(int id);
    }
}
