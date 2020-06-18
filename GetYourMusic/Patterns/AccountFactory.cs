
using GetYourMusic.Domain.Models;
using GetYourMusic.Domain.Models.Locations;
using GetYourMusic.Domain.Models.UserProfileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Test
{
    public class AccountFactory
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PersonalWeb { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public string AccountType { get; set; }
        public User User { get; set; }
        public int DistrictId { get; set; }
        public virtual Account GetAccount()
        {
            throw new NotImplementedException();
        }
    }
}
