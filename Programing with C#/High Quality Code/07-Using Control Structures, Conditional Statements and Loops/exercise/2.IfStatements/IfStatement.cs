using System;

class Program
{
    private  const int MIN_X = -200;
    private const int MAX_X = 200;
    private const int MIN_Y = -200;
    private const int MAX_Y = 200;
    private static void Main()
    {
        Potato potato = null;
//... 
        if (potato != null)
        {
            if (!potato.HasNotBeenPeeled && !potato.IsRotten)
            {
                Cook(potato);
            }
        }

        int x = 2;
        int y = 5;
        bool shouldNotVisitCell = true;
        if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell))
        {
           VisitCell();
        }

    }

    private static void VisitCell()
    {
        throw new NotImplementedException();
    }

    private static void Cook(Potato potato)
    {
        throw new NotImplementedException();
    }
}

internal class Potato
{
    public bool HasNotBeenPeeled { get; set; }
    public bool IsRotten { get; set; }
}
