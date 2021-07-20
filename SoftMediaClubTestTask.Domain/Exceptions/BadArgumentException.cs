using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.Domain.Exceptions
{
    public class BadArgumentException : Exception
    {
        public BadArgumentException(string message) : base(message)
        { 
        }
    }
}
