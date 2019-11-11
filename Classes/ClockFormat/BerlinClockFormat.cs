using System;
using System.Text.RegularExpressions;


namespace BerlinClock
{
    //BerlinClockFormat is an internal class because of the user just interested in converting time
    internal class BerlinClockFormat : ClockFormat
    {
        private TimeValidator timeValidator = null;
        private string yellow = "Y"; // Yellow Color
        private string red = "R"; // Red Color

        public override string HourColor { get { return red; } }
        public override string MinuteColor { get { return yellow; } }

        public BerlinClockFormat()
        {
            timeValidator = new TimeValidator();
        }

       
        //Accepts time object to convert into the berlin clock format string which has been defined in specfile.
        public override string FormatTime(string time)
        {
            //string validation is necessary for stable code.
            time = timeValidator.ValidateTimeWithColon(time);

            if (string.IsNullOrEmpty(time))
                return string.Empty;

            //accepting simpletime format.
            ParseTime = time;

            string retVal = string.Empty;
            retVal += formatSeconds(Seconds) + Environment.NewLine;
            retVal += formatHours(Hours) + Environment.NewLine;
            retVal += formatMinutes(Minutes);

            return retVal;
        }

        //Converts hours - Second and Third rows
        private string formatHours(int hours)
        {
            //For example, when an hour is 16, The Second row has 4 places for each lamp and onLights are in 3 and lightColor is in Red
            //One lamp in the second row corresponds to 5 hours so the remaining hour is equal to 1 after the operation(16 % 5)
            //Also, Third - row has 4 places but each lamp in the third row shows one hour
            //The Third - row has only one opens up
            int secondRow = hours / 5;
            int thirdRow = hours % 5;

            return stateLamp(4, secondRow) + 
                Environment.NewLine + stateLamp(4, thirdRow);
        }

        //Converts Minutes - Bottom two rows
        private string formatMinutes(int minutes)
        {
            //For example, when a minute is 40, The Fourth row has 11 places for each lamp and onLights are in 8 and ligtColor is in yellow
            //One lamp in the fourth row corresponds to 5 minutes so the remaning minutes is 0 after the operation(40 % 5)
            //The return value of the stateLamp function is 8 yellow lamps + 3 off lamps, however, 
            //Each and every triplet of yellows should be converted into the double yellow + one red.
            //The Fifth-row has all lamps are in off.

            int fourthRow = minutes / 5;
            int fifthRow = minutes % 5;

            return Regex.Replace(stateLamp(11,fourthRow, yellow),
                yellow + yellow + yellow,
                yellow + yellow + red) 
                + Environment.NewLine +
                stateLamp(4, fifthRow, yellow);
        }

        //Converts Seconds - Top row
        private string formatSeconds(int seconds)
        {
            return seconds % 2 == 0 ? yellow : LampOff;
        }

        //Checks whether the lamps are On/Off
        private string stateLamp(int lamps, int onLight)
        {
            return stateLamp(lamps, onLight, red);
        }

       
        private string stateLamp(int lamps, int onLights, string lightColor)
        {
            string output = string.Empty;
            int counter = 0;
            //Those will be turned on
            for (; counter < onLights; counter++)
            {
                output += lightColor;
            }
            //The Remaining lamps will be turned off if there exist
            for (counter = 0; counter < (lamps - onLights); counter++)
            {
                output += LampOff;
            }
            return output;
        }

    }
}
