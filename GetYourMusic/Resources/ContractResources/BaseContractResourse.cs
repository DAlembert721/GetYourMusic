using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources
{
    public class BaseContractResourse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PaymentAmount { get; set; }
        public string Address { get; set; }
        public string Reference { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float PerformerRating { get; set; }
        //public bool HasEquipment { get; set; }
        public string State { get; set; }
    }
}
