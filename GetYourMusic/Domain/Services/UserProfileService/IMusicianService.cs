using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services
{
    public interface IMusicianService
    {
        Task<IEnumerable<Musician>> ListAsync();
        Task<MusicianResponse> UpdateAsync(int id, Musician musician);
        Task<MusicianResponse> DeleteAsync(int id);
        Task<MusicianResponse> GetByIdAsync(int id);
        Task<IEnumerable<Musician>> ListByGenreIdAsync(int genreId);
        Task<IEnumerable<Musician>> ListByName(string name);
        Task<IEnumerable<Musician>> ListByInstrumentIdAsync(int instrumentId);
        Task<IEnumerable<Musician>> ListByDistrictIdAsync(int districtId);
        Task<IEnumerable<Musician>> ListByFollowerIdAsync(int followerId);
    }
}
