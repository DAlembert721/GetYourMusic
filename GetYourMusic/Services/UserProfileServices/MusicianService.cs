using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Repositories;
using GetYourMusic.Domain.Services;
using GetYourMusic.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace GetYourMusic.Services
{
    public class MusicianService : IMusicianService
    {
        private readonly IMusicianRepository _musicianRepository;
        private readonly IMusicianGenreRepository _musicianGenreRepository;
        private readonly IMusicianInstrumentRepository _musicianInstrumentRepository;
        private readonly IFollowRepository _followRepository;
        public readonly IUnitOfWork _unitOfWork;

        

        public MusicianService(IMusicianRepository musicianRepository, IMusicianGenreRepository musicianGenreRepository,
            IMusicianInstrumentRepository musicianInstrumentRepository, IFollowRepository followRepository, IUnitOfWork unitOfWork)
        {
            _musicianRepository = musicianRepository;
            _musicianGenreRepository = musicianGenreRepository;
            _musicianInstrumentRepository = musicianInstrumentRepository;
            _followRepository = followRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Musician>> ListAsync()
        {
            return await _musicianRepository.ListAsync();
        }

        public async Task<MusicianResponse> GetByIdAsync(int id)
        {
            var existingPerformer = await _musicianRepository.FindById(id);

            if (existingPerformer == null)
                return new MusicianResponse("Musician nor found");
            return new MusicianResponse(existingPerformer);
        }

        public async Task<MusicianResponse> UpdateAsync(int id, Musician performer)
        {
            var existingPerformer = await _musicianRepository.FindById(id);

            if (existingPerformer == null)
                return new MusicianResponse("Musician not found");

            existingPerformer.FirstName = performer.FirstName;
            existingPerformer.LastName = performer.LastName;
            existingPerformer.Phone = performer.Phone;
            existingPerformer.PersonalWeb = performer.PersonalWeb;
            existingPerformer.BirthDate = performer.BirthDate;
            existingPerformer.Description = performer.Description;
            existingPerformer.Rating = performer.Rating;

            try
            {
                _musicianRepository.Update(existingPerformer);
                await _unitOfWork.CompleteAsync();

                return new MusicianResponse(existingPerformer);
            }
            catch (Exception ex)
            {
                return new MusicianResponse($"An error has ocurred while updating musician: {ex.Message}");
            }
        }

        public async Task<MusicianResponse> DeleteAsync(int id)
        {
            var existingPerformer = await _musicianRepository.FindById(id);

            if (existingPerformer == null)
                return new MusicianResponse("Musician not found");

            try
            {
                _musicianRepository.Remove(existingPerformer);
                await _unitOfWork.CompleteAsync();

                return new MusicianResponse(existingPerformer);
            }
            catch (Exception ex)
            {
                return new MusicianResponse($"An error has ocurred while deleting musician: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Musician>> ListByGenreIdAsync(int genreId)
        {
            var musicianGenres = await _musicianGenreRepository.ListByGenreIdAsync(genreId);
            var musicians = musicianGenres.Select(pt => pt.Musician).ToList();
            return musicians;
        }

        public async Task<IEnumerable<Musician>> ListByInstrumentIdAsync(int instrumentId)
        {
            var musicianInstruments = await _musicianInstrumentRepository.ListByInstrumentIdAsync(instrumentId);
            var musicians = musicianInstruments.Select(pt => pt.Musician).ToList();
            return musicians;
        }
        
        public async Task<IEnumerable<Musician>> ListByDistrictIdAsync(int districtId)
        {
            return await _musicianRepository.ListByDistrictIdAsync(districtId);
        }

        public async Task<IEnumerable<Musician>> ListByName(string name)
        {
            return await _musicianRepository.FindMusicianByName(name);
        }

        public async Task<IEnumerable<Musician>> ListByFollowerIdAsync(int followerId)
        {
            var follow = await _followRepository.ListByFollowerIdAsync(followerId);
            var followed = follow.Select(f => f.Followed).ToList();
            return followed;
        }
    }
}
