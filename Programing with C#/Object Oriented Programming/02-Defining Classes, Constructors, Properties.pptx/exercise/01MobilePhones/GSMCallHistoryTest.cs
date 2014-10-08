using System.Collections.Generic;

namespace _01MobilePhones
{
    class GSMCallHistoryTest
    {

        public void testMe()
        {
            //        Create an instance of the GSM class.
            GSM mobileGSM = new GSM();
            //Add few calls.
            int fewCalls = 5;
            for (int i = 0; i < fewCalls; i++)
            {
               // mobileGSM.AddCalls();
            }

            //Display the information about the calls.
            List<Calls> listCall = mobileGSM.CallHistory;
            foreach (Calls call in listCall)
            {

            }
        }


    }
}
