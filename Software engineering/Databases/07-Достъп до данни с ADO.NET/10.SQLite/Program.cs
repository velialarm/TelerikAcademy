using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        SQLiteConnection connection = new SQLiteConnection(@"Data Source=C:\Users\Plamen\SkyDrive\IV Semester\Databases\7. ADO.NET\Homework\ADO.NET\10.SQLite\Library.db;Version=3;");
        AddBook(3, "JS UI", "Doncho", 2013, "911-22-11", connection);
        ShowListOfAllBooks(connection);
        FindBook("JS APPS", connection);
    }

    static void AddBook(int id, string title, string author, int year, string isbn, SQLiteConnection mySqlConnection)
    {
        SQLiteCommand command = new SQLiteCommand("INSERT INTO Books (id,title,author,publish_date,isbn) VALUES (@id,@title, @author, @year,@isbn)", mySqlConnection);
        mySqlConnection.Open();
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@title", title);
        command.Parameters.AddWithValue("@author", author);
        command.Parameters.AddWithValue("@year", year);
        command.Parameters.AddWithValue("@isbn", isbn);
        command.ExecuteNonQuery();
        mySqlConnection.Close();
    }

    static void FindBook(string bookTitle, SQLiteConnection connection)
    {
        SQLiteCommand findCommand = new SQLiteCommand
            ("SELECT author,title,publish_date FROM books WHERE title ='" + bookTitle + "';", connection);
        connection.Open();
        var reader = findCommand.ExecuteReader();

        while (reader.Read())
        {
            string author = (string)reader["author"];
            string title = (string)reader["title"];
            int year = (int)reader["publish_date"];

            Console.WriteLine("The book that you search for was written by {0} in {1} and it's title is {2}", author, year, title);
        }

        connection.Close();
    }

    static void ShowListOfAllBooks(SQLiteConnection connection)
    {
        SQLiteCommand command = new SQLiteCommand("SELECT title FROM Books", connection);
        connection.Open();
        var reader = command.ExecuteReader();

        while (reader.Read())
        {
            string bookTitle = (string)reader["title"];
            Console.WriteLine(bookTitle);
        }

        connection.Close();
    }
}
