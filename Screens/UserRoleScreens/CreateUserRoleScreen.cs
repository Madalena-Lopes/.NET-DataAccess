using Blog.Models;
using Blog.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.UserRoleScreens
{
    public class CreateUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criar vínculo utilizador/perfil");
            Console.WriteLine("-------------");
            Console.WriteLine("Qual o id do utilizador? ");
            var userId = Console.ReadLine();

            Console.WriteLine("Qual o id do perfil? ");
            var roleId = Console.ReadLine();

            Create(int.Parse(userId), int.Parse(roleId));
            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        public static bool Create(int userId, int roleId)
        {
            var repository = new Repository<User>(Database.Connection);
            var user = repository.Get(userId);
            if (user == null)
                return false;
            var repository2 = new Repository<Role>(Database.Connection);
            var role = repository2.Get(roleId);
            if (role == null)
                return false;
            var query = @"
                INSERT INTO 
                    [UserRole] 
                (UserId, RoleId)    
                VALUES(@UserId,@RoleId)";
            bool res;

            try
            {
                var rows = Database.Connection.Execute(query, new
                {
                    userId,
                    roleId
                });
                Console.WriteLine("Utilizador <-> Perfil ligado!");
                res = rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível vincular Utilizador <-> Perfil.");
                Console.WriteLine(ex.Message);// às vezes não é mt bom exibir mensagem de erro assim, mas neste caso tudo bem. 
                res = false;
            }            
            
            return res;
        }
    }
}
