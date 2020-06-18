using GetYourMusic.Domain.Models.ContractSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Services.Communications
{
    public class QualificationResponse : BaseResponse<Qualification>
    {
        public QualificationResponse(string message) : base(message) { }

        public QualificationResponse(Qualification qualification) : base(qualification) { }
    }
}
