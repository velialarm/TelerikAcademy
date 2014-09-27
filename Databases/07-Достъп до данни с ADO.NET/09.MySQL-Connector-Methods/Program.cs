﻿using System;
using MySql.Data.MySqlClient;

class Program
{
    static MySqlConnection mySqlConn = new MySqlConnection(@"Server=localhost;Port=3306;Database=library;Uid=root;Pwd=f9a300eb;");

    static void Main()
    {
        //AddBook("JS APPS", "Doncho", "2013", "987-222-14", mySqlConn); // ISBN is unique
        FindBook("Voivodata", mySqlConn);
        ShowListOfAllBooks(mySqlConn);
    }

    static void AddBook(string title, string author, string year, string ISBN, MySqlConnection mySqlConnection)
    {
        MySqlCommand command = new MySqlCommand("INSERT INTO books (title,author,publish_date,ISBN) VALUES (@title, @author, @year,@ISBN)", mySqlConnection);
        mySqlConnection.Open();
        command.Parameters.AddWithValue("@title", title);
        command.Parameters.AddWithValue("@author", author);
        command.Parameters.AddWithValue("@year", year);
        command.Parameters.AddWithValue("@ISBN", ISBN);
        command.ExecuteNonQuery();
        mySqlConnection.Close();
    }

    static void FindBook(string bookTitle, MySqlConnection connection)
    {
        MySqlCommand findCommand = new MySqlCommand
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


    static void ShowListOfAllBooks(MySqlConnection connection)
    {
        MySqlCommand command = new MySqlCommand("SELECT title FROM Books", connection);
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

