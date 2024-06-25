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
    public class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Apagar Post");
            Console.WriteLine("-----------");
            Console.WriteLine("Qual o id do post a apagar? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuPostScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Post>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Post apagado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível apagar o post.");
                Console.WriteLine(ex.Message);// às vezes não é mt bom exibir mensagem de erro assim, mas neste caso tudo bem. 
            }
        }
    }
}
