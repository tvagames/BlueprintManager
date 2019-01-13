using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueprintManager
{
    class BpmException : Exception
    {
        public BpmException(string message) : base(message)
        {
        }
    }
}
