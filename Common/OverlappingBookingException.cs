using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class OverlappingBookingException : Exception
    {
        public OverlappingBookingException() { }
        public OverlappingBookingException(string message) : base(message) { }
    }
}
