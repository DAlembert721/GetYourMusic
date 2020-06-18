using System;
using System.Collections.Generic;

namespace GetYourMusic.Domain.Models.ContractSystem
{
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float PaymentAmount { get; set; }
        public string  Address { get; set; }
        public string Reference { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float PerformerRating { get; set; }
        //public bool HasEquipment { get; set; }

        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }

        public int MusicianId { get; set; }
        public Musician Musician { get; set; }

        public int ContractStateId { get; set; }
        public ContractState ContractState { get; set; }
        public Qualification Qualification { get; set; }
        //public int DistrictId { get; set; }
        //public District District { get; set; }
    }
}
