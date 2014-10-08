using System;
using System.Collections.Generic;
using Chat.Models;

namespace Chat.Data
{
    public interface IChatController
    {
        void AddPost(Post post);

        void AddUser(User user);

        List<Post> GetPosts(DateTime startDate, DateTime endDate);

        List<Post> GetAllPosts();
    }
}