using GetYourMusic.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Repositories
{
    public interface IMusicianRepository
    {
        Task<IEnumerable<Musician>> ListAsync();
        Task<Musician> FindById(int id);
        void Update(Musician musician);
        void Remove(Musician musician);
        Task<IEnumerable<Musician>> FindMusicianByName(string name);
        Task<IEnumerable<Musician>> ListByDistrictIdAsync(int districtId);
    }
}
