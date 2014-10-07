using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        String getLine = @"44+623/5+(4*9-8)/7*2";
        String fpart;
        int index = 0;
        int insect;
        String mustCalc;
        StringBuilder sb = new StringBuilder();
        while (index != -1)
        {
            index = getLine.IndexOf('(', index);
            if (index == -1)
            {
                break;
            }
            int fBr = index;
            fpart = getLine.Substring(0, index);

            index = getLine.IndexOf(')', index);
            mustCalc = getLine.Substring(fBr + 1, index - fBr - 1);
            string result = calculate(mustCalc);

            sb.Append(fpart);
            sb.Append(result);

            int checEnd = getLine.IndexOf('(', index);
            if (checEnd == -1 && checEnd < getLine.Length)
            {
                sb.Append(getLine.Substring(index + 1, getLine.Length - index - 1));
            }

            //String f = getLine.Substring(0, index);
            Console.WriteLine(sb);
        }

    }

    private static string calculate(String getLine)
    {
        Stack tempStack = new Stack();
        Stack operandStack = new Stack();
        char[] listOperand = { '+', '-', '*', '/', '(', ')', ' ', };
        //String getLine = Console.ReadLine();
        //String getLine = @"44+623/5+(4*9-8)/7*2";
        //String getLine = @"3+7";
        //Extracting the Numbers
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
        //char[] operandi
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
        decimal result = listNumbers[0];
        for (int i = 1; i < listNumbers.Count; i++)
        {
            char operation = operators[i - 1];
            int nextNumber = listNumbers[i];

            result = calculate(result, operation);
        }
        Console.WriteLine(result);
        return "12.4";
    }
    private static decimal calculate(decimal result, char operation)
    {
        if (operation == '+')
        {
            result += result;
        }
        if (operation == '-')
        {
            result -= result;
        }
        if (operation == '/')
        {
            result /= result;
        }
        if (operation == '*')
        {
            result *= result;
        }
        return result;
    }
}

