using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    internal class TimeValidator : ITimeValidator
    {
        //The expected string format
        private string _regExpTimeFormatWithColon = "^(0[0-9]|1[0-9]|2[0-4]):[0-5][0-9]:[0-5][0-9]$";
        private string _regExpTimeFormatWithSlash = "^(0[0-9]|1[0-9]|2[0-4])/[0-5][0-9]/[0-5][0-9]$";

        public string ValidateTimeWithColon(string aTime)
        {
            string convertedTime = string.Empty;
            bool IsEligible = false;
            //Check whether string is in the correct format or not so that program flow keeps in strong.
            Regex regex = new Regex(_regExpTimeFormatWithColon);

            //if the input is eligible for creating time object
            IsEligible = regex.IsMatch(aTime);

            if (IsEligible)
            {
                convertedTime = aTime;
            }

            return convertedTime;
           
        }


        public string ValidateTimeWithSlash(string aTime)
        {
            string convertedTime = string.Empty;
            bool IsEligible = false;
            //Check whether string is in the correct format or not so that program flow keeps in strong.
            Regex regex = new Regex(_regExpTimeFormatWithSlash);

            //if the input is eligible for creating time object
            IsEligible = regex.IsMatch(aTime);

            if (IsEligible)
            {
                convertedTime = aTime;
            }

            return convertedTime;

        }

    }
}
