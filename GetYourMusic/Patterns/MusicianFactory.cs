using GetYourMusic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetYourMusic.Test
{
    public class MusicianFactory : AccountFactory
    {
        public override Account GetAccount()
        {
            return new Musician();
        }
    }
}
