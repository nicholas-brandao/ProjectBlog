﻿using ProjectBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBlog.Service
{
    public interface IBlogService
    {

        IEnumerable<BlogPost> GetBlogPosts();
        IEnumerable<BlogPost> GetOlderPosts(int oldestBlogPostId);
        string GetPostText(string link);


    }
}
