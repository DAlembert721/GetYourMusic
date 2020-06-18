using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLibrary
{
    class OrganizerFactory<T, U, O> : AccountFactory<T, U> where T : new()
    {
        public OrganizerFactory(T _t, U _u) : base(_t, _u) { }
        public override T GetAccount()
        {
            return new T();
            // return new O();
        }
    }
}
