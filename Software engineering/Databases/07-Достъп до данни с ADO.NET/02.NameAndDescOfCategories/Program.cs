using System;
using System.Data.SqlClient;

class Program
{
    //Write a program that retrieves the name and description of all categories in the Northwind DB.

    static void Main()
    {
        SqlConnection db = new SqlConnection("Server=PLAMEN; " +
            "Database=NORTHWND; Integrated Security=true");

        db.Open();
        using (db)
        {
            SqlCommand categoryInfoCommand = new SqlCommand("SELECT CategoryName, Description FROM Categories;",db);
            SqlDataReader reader = categoryInfoCommand.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string catName = (string)reader["CategoryName"];
                    string catDesc = (string)reader["Description"];
                    Console.WriteLine("{0} - {1}", catName, catDesc);
                }
            }
        }
    }
}

