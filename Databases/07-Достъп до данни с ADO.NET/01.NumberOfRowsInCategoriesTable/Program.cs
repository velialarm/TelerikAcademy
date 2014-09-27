using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        //1.Write a program that retrieves from the Northwind sample database in MS SQL Server
        //the number of  rows in the Categories table.

        SqlConnection databaseConnection = new SqlConnection("Server=PLAMEN; " +
            "Database=NORTHWND; Integrated Security=true");

        databaseConnection.Open();
        using (databaseConnection)
        { 
            SqlCommand commandCount = new SqlCommand("SELECT COUNT(CategoryID) FROM Categories;", databaseConnection);
            int categoriesCount = (int)commandCount.ExecuteScalar();
            Console.WriteLine("Categories count = {0}",categoriesCount);
        }
    }
}

