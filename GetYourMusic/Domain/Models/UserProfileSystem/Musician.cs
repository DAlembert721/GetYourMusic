using GetYourMusic.Domain.Models.ContractSystem;
using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Models.UserProfileSystem;
using System.Collections.Generic;

namespace GetYourMusic.Domain.Models
{
    public class Musician : Account
    {
        public string Description { get; set; }
        public float Rating { get; set; }
        public IList<Contract> Contracts { get; set; } = new List<Contract>();
        public List<MusicianGenre> MusicianGenres { get; set; }
        public List<MusicianInstrument> MusicianInstruments { get; set; }
        public IList<Publication> Publications { get; set; } = new List<Publication>();
        public IList<Qualification> Qualifications { get; set; } = new List<Qualification>();
        public IList<Follow> Followers { get; set; } = new List<Follow>();
        public IList<Follow> Followed { get; set; } = new List<Follow>();

        //public IList<Performer> Followers { get; set; } = new List<Performer>();

        //public IList<Performer> Following { get; set; } = new List<Performer>();
    }
}

