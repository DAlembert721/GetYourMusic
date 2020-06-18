using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLibrary
{
    public class MusicianFactory<T, U, M> : AccountFactory<T, U> where T : new()
    {
        public MusicianFactory(T _t, U _u) : base(_t, _u) { }
        public override T GetAccount()
        {
            return new T();
           // return new M();
        }
    }
}
