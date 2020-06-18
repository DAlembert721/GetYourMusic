using GetYourMusic.Domain.Models.ContractSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class ContractResponse : BaseResponse<Contract>
    {
        public ContractResponse(string message) : base(message) { }

        public ContractResponse(Contract contract) : base(contract) { }
    }
}
