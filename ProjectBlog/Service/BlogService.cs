using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using ProjectBlog.Models;

namespace ProjectBlog.Service
{
    public class BlogService : IBlogService
    {

        private IHostingEnvironment _env;
        public BlogService(IHostingEnvironment env)
        {
            _env = env;
        }

        private List<BlogPost> Posts
        {
            get
            {
                return new List<BlogPost>() {
                new BlogPost { Id = 1, Title = "Obter posts via API", ShortDescription = "Como usar fetch para obter uma lista de posts do blog" },
                new BlogPost { Id = 2, Title = "Usando Indexed DB", ShortDescription = "Como salvar lista de posts utilizando indexed DB" },
                new BlogPost { Id = 3, Title = "Gravando posts do blog no cache", ShortDescription = "Como usar a Cache API para salvar posts de blog que podem ser acessados offline" },
                new BlogPost { Id = 4, Title = "Obtendo dado em cache com Service Worker", ShortDescription = "Como utilizar Service Worker para obter dado do cache quando o usuário está offline" },
                new BlogPost { Id = 5, Title = "Criando uma Web App instalável", ShortDescription = "Como criar arquivos que permitem que você instale o seu aplicativo no seu celular" },
                new BlogPost { Id = 6, Title = "Enviando notificações push", ShortDescription = "Como enviar notificações push que permitem notificar o usuário que tem o seu aplicativo instalado" },
                new BlogPost { Id = 7, Title = "Micro front ends", ShortDescription = "Como criar Micro front ends" },
                new BlogPost { Id = 8, Title = "Blazor", ShortDescription = "Como implementar uma SPA com Blazor client-side" },
                new BlogPost { Id = 9, Title = "Xamarim", ShortDescription = "Como implementar uma aplicação Xamarim" },
                new BlogPost { Id = 10, Title = "Unity", ShortDescription = "Como implementar uma aplicação Unity" },
                new BlogPost { Id = 11, Title = "Angular", ShortDescription = "Como implementar uma aplicação Angular" },
                new BlogPost { Id = 12, Title = "React", ShortDescription = "Como implementar uma aplicação React" }
            };
            }
        }

        public string GetPostText(string link)
        {
            var post = Posts.FirstOrDefault(_ => _.Link == link);

            return File.ReadAllText($"{_env.WebRootPath}/Posts/{post.Id}_post.md");
        }
        public IEnumerable<BlogPost> GetBlogPosts()
        {
            return Posts.OrderByDescending(_ =>
           _.Id).Take(3).ToList();
        }

        public IEnumerable<BlogPost> GetOlderPosts(int oldestPostId)
        {
            var posts = Posts.Where(_ => _.Id <
           oldestPostId).OrderByDescending(_ => _.Id).ToList();
            if (posts.Count < 3)
                return posts;
            return posts.Take(3).ToList();
        }

    }
}
