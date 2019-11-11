using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    internal interface ITimeValidator
    {
        string ValidateTimeWithColon(string aTime);
        string ValidateTimeWithSlash(string aTime);
    }
}
