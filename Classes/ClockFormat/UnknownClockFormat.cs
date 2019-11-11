using System;

namespace BerlinClock
{
    internal class UnknownClockFormat : ClockFormat
    { 
        //For different scenario
        public UnknownClockFormat()
        {
        }
        public override string HourColor => throw new NotImplementedException();

        public override string MinuteColor => throw new NotImplementedException();

        public override string FormatTime(string time)
        {
            throw new NotImplementedException();
        }
    }
}
