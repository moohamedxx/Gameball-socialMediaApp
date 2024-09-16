using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Repository.Data
{
    public static class DataSeeds
    {
        public static async Task SeedsAsync(SocialMediaContext DbContext)
        {
            if (!DbContext.Users.Any())
            {
                var usersData = File.ReadAllText("../Repository/Data/Json/Users.json");
                var Users= JsonSerializer.Deserialize<List<UserEntity>>(usersData);
                if(Users?.Count() > 0)
                {
                    foreach(var user in Users)
                    {
                        await DbContext.Users.AddAsync(user);
                        await DbContext.SaveChangesAsync();
                    }
                }
            }
            if(!DbContext.Posts.Any()) {
                var PostsData = File.ReadAllText("../Repository/Data/Json/Posts.json");
                var Posts=JsonSerializer.Deserialize<List<PostEntity>>(PostsData);
                if(Posts?.Count() > 0)
                {
                    foreach (var post in Posts)
                    {
                        await DbContext.Posts.AddAsync(post);
                        await DbContext.SaveChangesAsync();
                    }
                }
            }
            if(!DbContext.Comments.Any()) {

                var CommentsData = File.ReadAllText("../Repository/Data/Json/Comments.json");
                var Comments=JsonSerializer.Deserialize<List<CommentEntity>>(CommentsData);
                if(Comments?.Count() > 0)
                {
                    foreach (var comment in Comments)
                    {
                        await DbContext.Comments.AddAsync(comment);
                        await DbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
