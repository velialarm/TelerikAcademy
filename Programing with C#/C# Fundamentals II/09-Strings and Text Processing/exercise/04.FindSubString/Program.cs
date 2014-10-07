using System;
class FindSubString
{
    static void Main()
    {
        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days".ToUpper();
        string searchWord = "in".ToUpper();
        int index = -1;
        int count = 0;
        while (true)
	    {
            index = text.IndexOf(searchWord, index+1);
             if (index== -1)
             {
                 break;
             }
             count++;
	    }
        Console.WriteLine(count);
    }
}
