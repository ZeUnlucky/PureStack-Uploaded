using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PureStack.Classes
{
    public class DALException : Exception
    {
        private Exception _nestedException;
        public DALException(Exception e) : base()
        {
            _nestedException = e;
        }

    }
}
