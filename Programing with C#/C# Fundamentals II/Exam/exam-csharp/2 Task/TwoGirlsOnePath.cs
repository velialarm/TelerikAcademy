using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

class TwoGirlsOnePath
{
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }

        string[] buff = Console.ReadLine().Split();
        BigInteger[] flowers = new BigInteger[buff.Length];
        for (int i = 0; i < buff.Length; i++)
        {
            flowers[i] = BigInteger.Parse(buff[i]);
        }
        int posPlayer1 = 0;
        int posPlayer2 = flowers.Length-1;
        BigInteger maxMatrixLenght = BigInteger.Subtract(flowers.Length, 1);
        BigInteger sumPlayer1 = 0;
        BigInteger sumPlayer2 = 0;
        string win = "";
        while (true)
        {
            // TODO position check 
            BigInteger curFlowerPlayer1 = flowers[posPlayer1];
            BigInteger curFlowerPlayer2 = flowers[posPlayer2];
            sumPlayer1 = BigInteger.Add(sumPlayer1, curFlowerPlayer1); //result Molly
            sumPlayer2 = BigInteger.Add(sumPlayer2,curFlowerPlayer2); //result Dolly
            if (curFlowerPlayer1 == 0 && curFlowerPlayer2 == 0)
            {
                 win = "Draw";
                 break;
            }else if (curFlowerPlayer1 == 0)
            {
                win = "Dolly";
                break;
            }else if (curFlowerPlayer2 == 0)
            {
                win = "Molly";
                break;
            }
          
            // remove flowers
            //int tempPos1 = posPlayer1;
            //int tempPos2 = posPlayer2;
            flowers[posPlayer1] = 0;
            flowers[posPlayer2] = 0;
            //move to next possition
            if (BigInteger.Add(posPlayer1, curFlowerPlayer1).CompareTo(maxMatrixLenght) > 0)
            {
                posPlayer1 = (int)BigInteger.Remainder(BigInteger.Add(posPlayer1, curFlowerPlayer1), maxMatrixLenght)-1;
            }
            else
            {
                posPlayer1 = (int)BigInteger.Add(posPlayer1,curFlowerPlayer1); 
            }

            if (BigInteger.Subtract(posPlayer2 , curFlowerPlayer2).CompareTo(0) < 0)
            {
                //posPlayer2 = flowers.Length + (posPlayer2 - (int)curFlowerPlayer2);

                posPlayer2 = (int)BigInteger.Remainder(BigInteger.Add(posPlayer2, curFlowerPlayer2), maxMatrixLenght);
                //posPlayer2 = (int)BigInteger.Remainder( BigInteger.Add(posPlayer2 , curFlowerPlayer2), BigInteger.Subtract(maxMatrixLenght, 1));
                //posPlayer2 = Math.Abs(posPlayer2 - (int)curFlowerPlayer2);
            }
            else
            {
                posPlayer2 = (int)(BigInteger.Subtract(posPlayer2, curFlowerPlayer2));
            }
        }

        Console.WriteLine(win);
        Console.WriteLine("{0} {1}",sumPlayer1,sumPlayer2);
    }
}

