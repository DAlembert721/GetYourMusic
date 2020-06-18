using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.ContractSystem
{
    public class Qualification
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        public int MusicianId { get; set; }
        public Musician Musician { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}
