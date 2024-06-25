using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.PostScreens
{
    public class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Post");
            Console.WriteLine("-------------");
            Console.WriteLine("Categoria: ");
            var categoryId = Console.ReadLine();

            Console.WriteLine("Autor: ");
            var authorId = Console.ReadLine();

            Console.WriteLine("Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("Resumo: ");
            var summary = Console.ReadLine();

            Console.WriteLine("Corpo: ");
            var body = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Console.WriteLine("Data Criação: ");
            var createDate = Console.ReadLine();

            Console.WriteLine("Data Atualização: ");
            var lastUpadateDate = Console.ReadLine();

            Create(new Post
            {
                CategoryId = int.Parse(categoryId),
                AuthorId = int.Parse(authorId),
                Title = title,
                Summary = summary,
                Body = body,
                Slug = slug,
                CreateDate = DateTime.Parse(createDate),
                LastUpdateDate = DateTime.Parse(lastUpadateDate)
            });
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Create(post);
                Console.WriteLine("Post gravado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível guardar o post.");
                Console.WriteLine(ex.Message);// às vezes não é mt bom exibir mensagem de erro assim, mas neste caso tudo bem. 
            }
        }
    }
}
