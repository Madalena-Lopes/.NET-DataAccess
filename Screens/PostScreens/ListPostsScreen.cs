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
    public class ListPostsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Pots");
            Console.WriteLine("-------------");
            //List();
            ListWithTags();
            Console.WriteLine("Lista de Pots da categoria 1");
            Console.WriteLine("----------------------------");
            ListWithTags( 1);
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Post>(Database.Connection);
            var items = repository.Get();
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.CategoryId}, {item.AuthorId}, {item.Title}, {item.Summary}, {item.Body}, {item.Slug}, {item.CreateDate}, {item.LastUpdateDate}");
            }
        }

        private static void ListWithTags()
        {
            var repository = new PostRepository(Database.Connection);
            var items = repository.ReadWithTag();
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.CategoryId}, {item.AuthorId}, {item.Title}, {item.Summary}, {item.Body}, {item.Slug}, {item.CreateDate}, {item.LastUpdateDate}");
                foreach (var tag in item.Tags)
                    Console.WriteLine($" - {tag.Name}, {tag.Slug}");
            }
        }

        private static void ListWithTags( int categoryId)
        {
            var repository = new PostRepository(Database.Connection);
            var items = repository.ReadWithTag(categoryId);
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.CategoryId}, {item.AuthorId}, {item.Title}, {item.Summary}, {item.Body}, {item.Slug}, {item.CreateDate}, {item.LastUpdateDate}");
                foreach (var tag in item.Tags)
                    Console.WriteLine($" - {tag.Name}, {tag.Slug}");
            }
        }
    }
}
