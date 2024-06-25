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
    public class CreatePostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar vínculo Post/Tag");
            Console.WriteLine("----------------------");
            Console.WriteLine("Qual o id do Post? ");
            var postId = Console.ReadLine();

            Console.WriteLine("Qual o id da Tag? ");
            var tagId = Console.ReadLine();

            Create(int.Parse(postId), int.Parse(tagId));
            Console.ReadKey();
            MenuPostTagScreen.Load();
        }

        public static bool Create(int postId, int tagId)
        {
            var repository = new Repository<Post>(Database.Connection);
            var post = repository.Get(postId);
            if (post == null)
                return false;
            var repository2 = new Repository<Tag>(Database.Connection);
            var tag = repository2.Get(tagId);
            if (tag == null)
                return false;
            var query = @"
                INSERT INTO 
                    [PostTag] 
                (PostId, TagId)    
                VALUES(@PostId,@TagId)";
            bool res;

            try
            {
                var rows = Database.Connection.Execute(query, new
                {
                    postId,
                    tagId
                });
                Console.WriteLine("Post <-> Tag ligado!");
                res = rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular Post <-> Tag.");
                Console.WriteLine(ex.Message);// às vezes não é mt bom exibir mensagem de erro assim, mas neste caso tudo bem. 
                res = false;
            }

            return res;
        }
    }
}
