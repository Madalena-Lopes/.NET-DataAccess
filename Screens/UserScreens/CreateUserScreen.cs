using Blog.Models;
using Blog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.UserScreens
{
    public class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo utilizador");
            Console.WriteLine("-------------");
            Console.WriteLine("Nome: ");
            var name = Console.ReadLine();

            Console.WriteLine("Email: ");
            var email = Console.ReadLine();

            Console.WriteLine("Password: ");
            var password = Console.ReadLine();

            Console.WriteLine("Bio: ");
            var bio = Console.ReadLine();

            Console.WriteLine("Imagem: ");
            var image = Console.ReadLine();

            Console.WriteLine("Slug: ");
            var slug = Console.ReadLine();

            Create(new User
            {
                Name = name,
                Email = email,
                PasswordHash = password,
                Bio = bio,
                Image = image,
                Slug = slug
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Utilizador gravado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível guardar o utilizador.");
                Console.WriteLine(ex.Message);// às vezes não é mt bom exibir mensagem de erro assim, mas neste caso tudo bem. 
            }
        }
    }
}
