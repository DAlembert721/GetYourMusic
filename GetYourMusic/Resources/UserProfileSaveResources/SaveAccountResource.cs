using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Resources
{
    public class SaveAccountResource
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PersonalWeb { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public int DistrictId { get; set; }
    }
}
