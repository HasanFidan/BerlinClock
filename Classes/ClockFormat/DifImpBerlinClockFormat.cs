using System;
using System.Text.RegularExpressions;


namespace BerlinClock
{
    //The Different Implementation of BerlinClockFormat cost 
    //is to override ParseTime in the base class and inserting a new validation rule.
    internal class DifImpBerlinClockFormat : ClockFormat
    {
        private TimeValidator timeValidator = null;
        private string green = "G"; // Green Color
        private string red = "R"; // Red Color

        public override string HourColor { get { return red; } }
        public override string MinuteColor { get { return green; } }

        public DifImpBerlinClockFormat()
        {
            timeValidator = new TimeValidator();
        }

        protected override string ParseTime
            {
             set {

                string[] splitted = value.Split('/');
                Hours = Convert.ToInt32(splitted[0]);
                Minutes = Convert.ToInt32(splitted[1]);
                Seconds = Convert.ToInt32(splitted[2]);

            }}

        //Accepts time object to convert into the berlin clock format string which has been defined in specfile.
        public override string FormatTime(string time)
        {
            //string validation is necessary for stable code.
            time = timeValidator.ValidateTimeWithSlash(time);

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
            //What if the lamp number in the second-row might be 8 instead of 4 lamp
            //Also, The third-row number should be changed by 2
            int secondRow = hours / 3;
            int thirdRow = hours % 3;

            return stateLamp(8,secondRow) + 
                Environment.NewLine + stateLamp(2,thirdRow);
        }

        //Converts Minutes - Bottom two rows
        private string formatMinutes(int minutes)
        {
            int fourthRow = minutes / 5;
            int fifthRow = minutes % 5;

            return Regex.Replace(stateLamp(11, fourthRow, green),
                green + green + green,
                green + green + red) 
                + Environment.NewLine +
                stateLamp(4,fifthRow, green);
        }

        //Converts Seconds - Top row
        private string formatSeconds(int seconds)
        {
            return seconds % 2 == 0 ? green : LampOff;
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
