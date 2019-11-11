using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BerlinClock
{
    [Binding]
    internal class TheBerlinClockSteps
    {
        //BerlinClockFormat is a ClockFormat
        private ClockFormat cf = new BerlinClockFormat();
        private string theTime;

        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = cf.FormatTime(time);
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(theTime, theExpectedBerlinClockOutput);
        }

    }
}
