using System;
using System.Data.SqlClient;

class Program
{
    //Write a method that adds a new product in the products table in the Northwind database.
    //Use a parameterized SQL command.

    static void Main()
    {
        AddProduct("Swimming", true);
    }

    static void AddProduct(string name, bool discontinued)
    {
        SqlConnection dbCon = new SqlConnection("Server=PLAMEN; " +
            "Database=NORTHWND; Integrated Security=true");

        dbCon.Open();
        using (dbCon)
        {
            SqlCommand addProduct = new SqlCommand("INSERT Products (ProductName,Discontinued)" +
            "VALUES(@name,@discontinued);", dbCon);

            addProduct.Parameters.AddWithValue("@name", name);
            addProduct.Parameters.AddWithValue("@discontinued", discontinued);
            addProduct.ExecuteNonQuery();
        }
    }
}