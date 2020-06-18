using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.UserProfileSystem
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public Account Account { get; set; }
        //public int SuscriptionId { get; set; }
    }
}
