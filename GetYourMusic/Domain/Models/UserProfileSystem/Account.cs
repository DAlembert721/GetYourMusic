using GetYourMusic.Domain.Models.Locations;
using GetYourMusic.Domain.Models.Media_System;
using GetYourMusic.Domain.Models.UserProfileSystem;
using System;

using System.Collections.Generic;


namespace GetYourMusic.Domain.Models
{
    public class Account
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PersonalWeb { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public string AccountType { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

        public IList<Search> Searches { get; set; } = new List<Search>();

        public IList<Comment> Comments { get; set; } = new List<Comment>();

    }
}
