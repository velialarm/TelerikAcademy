using System;

namespace _01MobilePhones
{
    class Calls
    {
        private DateTime _dateCalls;
        private DateTime _timeCalls;

        public DateTime DateCalls { get { return _dateCalls; } set { _dateCalls = value; } }
        public DateTime TimeCalls { get { return _timeCalls; } set { _timeCalls = value; } }
        public string DialedPhoneNumber { get; set; }
        public int Duration { get; set; }
    }
}
