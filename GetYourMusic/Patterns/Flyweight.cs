using GetYourMusic.Domain.Models.ContractSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Patterns
{
    public class Flyweight
    {
        private Contract _sharedState;

        public Flyweight(Contract sharedState)
        {
            this._sharedState = sharedState;
        }
        public void Operation(Contract contract)
        {
            contract.ContractState = _sharedState.ContractState;
            contract.ContractStateId = _sharedState.ContractStateId;
            contract.Organizer = _sharedState.Organizer;
            contract.OrganizerId = _sharedState.OrganizerId;
            
        }

    }
}
