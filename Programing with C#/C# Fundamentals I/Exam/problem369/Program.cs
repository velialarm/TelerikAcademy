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
        Stack tempStack = new Stack();
        Stack operandStack = new Stack();
        char[] listOperand = { '+', '-', '*', '/', '(', ')', ' ', };
        //String getLine = Console.ReadLine();
        //String getLine = @"44+623/5+(4*9-8)/7*2";
        String getLine = @"3+7";
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
