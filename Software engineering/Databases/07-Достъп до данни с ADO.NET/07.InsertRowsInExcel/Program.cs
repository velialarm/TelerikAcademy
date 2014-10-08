using System;
using System.Data.OleDb;

class Program
{
    //7.Implement appending new rows to the Excel file.

    static void Main()
    {
        OleDbConnection dbConn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" +
           @"Data Source=C:\Users\Plamen\SkyDrive\IV Semester\Databases\7. ADO.NET\Homework\ADO.NET\07.InsertRowsInExcel\Table.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""");

        for (int i = 1; i < 10; i++)
        {
            InsertDataIntoEcxel("Nakov" + i, i, dbConn);
        }
    }

    static void InsertDataIntoEcxel(string name, double score, OleDbConnection connection)
    {
        OleDbCommand myCommand = new OleDbCommand("INSERT INTO [Sheet1$] (Name,Score) VALUES (@Name,@Score)", connection);
        connection.Open();
        myCommand.Parameters.AddWithValue("@Name", name);
        myCommand.Parameters.AddWithValue("@Score", score);
        myCommand.ExecuteNonQuery();
        connection.Close();
    }
}

