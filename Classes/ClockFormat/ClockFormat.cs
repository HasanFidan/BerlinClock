using System;

namespace BerlinClock
{
    // This class is an outline presents what the ClockFormat is. 
    
    public abstract class ClockFormat
    {
        private int _hours { get; set; }
        private int _seconds { get; set; }
        private int _minutes { get; set; }

        //For all lamp "off-state" is always the same
        protected string LampOff { get { return "O"; } }
        

        protected int Hours { get { return _hours; } set { _hours = value; } }
       
        protected int Minutes { get { return _minutes; } set { _minutes = value; } }
        
        protected int Seconds { get { return _seconds; } set { _seconds = value; } }


        //Time information is 12:34:12 as a simple format but the demonstration of the time can be changed by what customer needs.
        //Time separation and time demonstration can be changed by needs.
        protected virtual string ParseTime {
            set {

                string[] splitted = value.Split(':');
                _hours = Convert.ToInt32(splitted[0]);
                _minutes = Convert.ToInt32(splitted[1]);
                _seconds = Convert.ToInt32(splitted[2]);

            }
        }

        //What if the Berlin Clock Colors may be changed by different scenarios
        public abstract string HourColor { get; }
        public abstract string MinuteColor { get; }

        public abstract string FormatTime(string time);
    }
}
