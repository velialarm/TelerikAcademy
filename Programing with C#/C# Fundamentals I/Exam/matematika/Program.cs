using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        String getLine = @"44+623/5+(4*9-8)/7*2";
        char[] listOperand = { '+', '-', '*', '/', '(', ')', ' ', };
        String[] numbers = getLine.Split(listOperand);
        List<int> listNumbers = new List<int>();
        for (int i = 0; i < numbers.Length; i++)
        {
            try
            {
                listNumbers.Add(Convert.ToInt32(numbers[i]));
            }
            catch (Exception)
            {
            }
        }
        // Extracting the Operators
        string operatorCharacters = "+-*/()";
        List<char> operators = new List<char>();
        foreach (char c in getLine)
        {
            if (operatorCharacters.Contains(c))
            {
                operators.Add(c);
            }
        }
        //CalculateExpression


        Console.WriteLine();
    }
}
