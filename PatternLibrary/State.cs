using System;
using System.Collections.Generic;
using System.Text;

namespace PatternLibrary
{
    abstract class State
    {
        public void SetContext()
        {
            
        }

        public abstract void Handle();
    }
}
