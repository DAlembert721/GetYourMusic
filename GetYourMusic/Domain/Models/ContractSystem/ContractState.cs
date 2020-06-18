using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.ContractSystem
{
    public class ContractState
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public IList<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
