using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Data;
using Chat.Models;

namespace Chat.ConsoleClient
{
    class ConsoleClient
    {
        static void Main()
        {
            var db = new MongoDbContext();
            IChatController chat = new ChatController(db);

            Console.WriteLine("Enter your Username: ");
            string username = Console.ReadLine();
            var loggedTime = DateTime.Now;
            //var user = string.IsNullOrEmpty(username) ? new User() : new User(username);
            var user = new User
            {
                Name = (string.IsNullOrEmpty(username) ? "guest" : username),
                LoggedTimeFrom = loggedTime
            };
            chat.AddUser(user);

            Console.WriteLine("Press Return for Exit");
            while (true)
            {
                Console.Write("Add Post: ");
                string readLine = Console.ReadLine();
                if (readLine.Length == 0)
                {
                    return;
                }

                chat.AddPost(new Post
                {
                    Content = readLine,
                    PostOn = DateTime.Now,
                    PostedByUser = user.Name
                });
            }

        }
    }
}
