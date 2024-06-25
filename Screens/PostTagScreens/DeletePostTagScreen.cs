using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserRoleScreens;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.PostTagScreens
{
    public class DeletePostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Apagar vínculo Post/Tag");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Qual o id do Post a apagar? ");
            var postId = Console.ReadLine();

            Console.WriteLine("Qual o id da Tag a apagar? ");
            var tagId = Console.ReadLine();

            Delete(int.Parse(postId), int.Parse(tagId));
            Console.ReadKey();
            MenuPostTagScreen.Load();
        }

        public static bool Delete(int postId, int tagId)
        {
            var repository = new Repository<Post>(Database.Connection);
            var post = repository.Get(postId);
            if (post == null)
            {
                Console.WriteLine("Não existe o Post!");
                return false;
            }
            var repository2 = new Repository<Tag>(Database.Connection);
            var tag = repository2.Get(tagId);
            if (tag == null)
            {
                Console.WriteLine("Não existe o perfil!");
                return false;
            }
            var query = @"
                DELETE FROM 
                    [PostTag] 
                WHERE PostId = @PostId and TagId = @TagId";
            bool res;

            try
            {
                var rows = Database.Connection.Execute(query, new
                {
                    postId,
                    tagId
                });
                Console.WriteLine("Ligação Post <-> Tag apagada!");
                res = rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível remover vínculo Post <-> Tag.");
                Console.WriteLine(ex.Message);// às vezes não é mt bom exibir mensagem de erro assim, mas neste caso tudo bem. 
                res = false;
            }

            return res;
        }
    }
}
