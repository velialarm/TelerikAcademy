using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


class DurankulakNumbers
{
    static void Main(string[] args)
    {
        Dictionary<String, int> azbuka = CreateAzbuka();
        string line = Console.ReadLine();
        //string line = "U";

        char[] data = line.ToCharArray();
        int i = 0;
        int value;
        List<int> sumList = new List<int>();
        while(i<data.Length)
        {
            if (Char.IsLower(data[i]))
            {
                azbuka.TryGetValue(data[i].ToString()+data[i+1].ToString(), out value);
                sumList.Add(value);
                i = i+2;
            }
            else
            {
                azbuka.TryGetValue(data[i].ToString(), out value);
                sumList.Add(value);
                i++;
            }
        }
        BigInteger result = 0;
        for (int rep = 0; rep <sumList.Count; rep++)
        {
            int element = sumList[sumList.Count-rep-1];
            BigInteger smetka = (BigInteger)Math.Pow(168, rep);
            BigInteger sumata = element * smetka;
            result += sumata;
        }
        Console.WriteLine(result);
    }

    private static Dictionary<String, int> CreateAzbuka()
    {
        //168
        Dictionary<String, int> azbuka = new Dictionary<string, int>();
        int count =0;
        for (char i = 'A'; i <= 'Z'; i++)
        {
            azbuka.Add(i.ToString(), count++);
        }
        for (char k = 'a'; k <= 'f'; k++)
        {
            for (char z = 'A'; z <= 'Z'; z++)
            {
                if (azbuka.Count > 167) {
                    return azbuka;
                }
                azbuka.Add(k.ToString() + z.ToString(), count++);
            }
        }
        return azbuka;
    }
}
