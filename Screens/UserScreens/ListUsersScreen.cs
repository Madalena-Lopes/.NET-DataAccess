using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.UserScreens
{
    public class ListUsersScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de utilizadores");
            Console.WriteLine("---------------------");
            //List();
            ListWithRole();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var items = repository.Get();
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.Name} | {item.Email} | {item.PasswordHash} | {item.Bio} | {item.Image} ({item.Slug})");
            }
        }

        private static void ListWithRole()
        {
            var repository = new UserRepository(Database.Connection);
            var items = repository.ReadWithRole();
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id} - {item.Name}, {item.Email}, {item.PasswordHash}, {item.Bio}, {item.Image}, ({item.Slug})");
                foreach (var role in item.Roles)
                    Console.WriteLine($" - {role.Name}, {role.Slug}");
            }
        }
    }
}
