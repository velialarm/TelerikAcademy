using System;
using System.Data.SqlClient;

class Program
{
    //Write a program that retrieves from the Northwind database 
    //all product categories and the names of the products in each category. 
    //Can you do this with a single SQL query (with table join)?

    static void Main()
    {
        SqlConnection dbCon = new SqlConnection("Server=PLAMEN; " +
            "Database=NORTHWND; Integrated Security=true");

        dbCon.Open();
        using (dbCon)
        {
            SqlCommand joinTable = new SqlCommand("SELECT c.CategoryName,p.ProductName FROM Categories c inner join Products p on c.CategoryID = p.CategoryID;", dbCon);
            SqlDataReader reader = joinTable.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                { 
                    string catName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("{0} - {1}", catName, productName);
                }
            }
        }
    }
}

