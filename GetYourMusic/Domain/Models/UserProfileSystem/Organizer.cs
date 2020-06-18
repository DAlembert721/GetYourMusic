
using GetYourMusic.Domain.Models.ContractSystem;
using System.Collections.Generic;

namespace GetYourMusic.Domain.Models
{
    public class Organizer : Account
    {
        public IList<Contract> Contracts { get; set; } = new List<Contract>();
        public IList<Qualification> Qualifications { get; set; } = new List<Qualification>();
    }
}
