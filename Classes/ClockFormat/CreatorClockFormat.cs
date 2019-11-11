
namespace BerlinClock
{

    //BerlinClockFormat and BDD should not be changed by customer new feedback or whatever
    //That's why The solution is ready to handle possible scenarios.

    public enum ClockFormats
    {
        BerlinClockFormat,
        DifImpBerlinClockFormat,
        UnknownClockFormat
    }

    public class CreatorClockFormat
    {
        private static CreatorClockFormat _instance;

        
        protected CreatorClockFormat()
        {
        }

        public static CreatorClockFormat Instance()
        {
            if (_instance == null)
            {
                _instance = new CreatorClockFormat();
            }
            return _instance;
        }

        public ClockFormat FactoryMethod(ClockFormats formats)
        {
            ClockFormat cf = null;
            switch (formats)
            {
                case ClockFormats.BerlinClockFormat:
                    cf = new BerlinClockFormat();
                    break;
                case ClockFormats.DifImpBerlinClockFormat:
                    cf = new DifImpBerlinClockFormat();
                    break;
                default:
                    cf = new UnknownClockFormat();
                    break;

            }

            return cf;
        }

       
    }
}
