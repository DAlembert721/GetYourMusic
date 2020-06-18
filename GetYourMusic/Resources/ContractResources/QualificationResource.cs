using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources.ContractResources
{
    public class QualificationResource
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }
        public string Musician { get; set; }
        public string Organizer { get; set; }
        public string Contract { get; set; }
    }
}
