﻿using RedditRetriever.Data.Database;
using RedditRetriever.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RedditRetriever.Data
{
    public class RedditRepository : IRedditRepository
    {
        public async Task SavePostsAsync(IEnumerable<Post> posts)
        {
            using(var ctx = new RedditDBDataContext())
            {
                try
                {
                    ctx.Posts.AddRange(posts);
                    await ctx.SaveChangesAsync();
                }
                catch(DbUpdateException)
                {

                }
            }
        }
    }
}