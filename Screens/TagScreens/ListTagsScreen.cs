using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.TagScreens
{
    public class ListTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuTagScreen.Load();
        }

        private static void List() 
        {
            var repository = new Repository<Tag>(Database.Connection);
            var items = repository.Get();//ir buscar todas as tags
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");

            }
        }
    }
}
