using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Domain.Models.UserProfileSystem
{
    public class Search
    {
        public int Id { get; set; }             
        public string Content { get; set; }
        public int Genre { get; set; }
        public int Instrument { get; set; }
        public int District { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
