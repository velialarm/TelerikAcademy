using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Models;
using MongoDB.Driver.Builders;

namespace Chat.Data
{
    public class ChatController :IChatController
    {
        private readonly MongoDbContext dbContext;

        public ChatController(MongoDbContext mongoDbContext)
        {
            this.dbContext = mongoDbContext;
        }

        public void AddPost(Post post)
        {
            this.dbContext.Posts.Insert(post);
        }

        public void AddUser(User user)
        {
            this.dbContext.Posts.Insert(user);
        }

        public List<Post> GetPosts(DateTime startDate, DateTime endDate)
        {
            var findPostsInDateRangeQuery = Query<Post>.Where(post => post.PostOn >= startDate && post.PostOn <= endDate);
            var posts = this.dbContext.Posts.Find(findPostsInDateRangeQuery);
            List<Post> result = new List<Post>();
            foreach (var post in posts)
            {
                result.Add(post);
            }
            return result;
        }

        public List<Post> GetAllPosts()
        {
             var query = Query<Post>.Where(post =>  post.PostOn <= DateTime.Now);
            var posts = this.dbContext.Posts.Find(query);
            List<Post> result = new List<Post>();
            foreach (var post in posts)
            {
                result.Add(post);
            }
            return result;
        }

    }
}
