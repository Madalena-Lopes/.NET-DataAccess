using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.UserRoleScreens
{
    public class DeleteUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Apagar vínculo utilizador/perfil");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Qual o id do utilizador a apagar? ");
            var userId = Console.ReadLine();

            Console.WriteLine("Qual o id do perfil a apagar? ");
            var roleId = Console.ReadLine();

            Delete(int.Parse(userId), int.Parse(roleId));
            Console.ReadKey();
            MenuUserRoleScreen.Load();
        }

        public static bool Delete(int userId, int roleId)
        {
            var repository = new Repository<User>(Database.Connection);
            var user = repository.Get(userId);
            if (user == null)
            { 
                Console.WriteLine("Não existe o utilizador!");
                return false;
            }
            var repository2 = new Repository<Role>(Database.Connection);
            var role = repository2.Get(roleId);
            if (role == null)
            { 
                Console.WriteLine("Não existe o perfil!");
                return false;
            }
            var query = @"
                DELETE FROM 
                    [UserRole] 
                WHERE UserId = @UserId and RoleId = @RoleId";
            bool res;

            try
            {
                var rows = Database.Connection.Execute(query, new
                {
                    userId,
                    roleId
                });
                Console.WriteLine("Ligação Utilizador <-> Perfil apagada!");
                res = rows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível remover vínculo Utilizador <-> Perfil.");
                Console.WriteLine(ex.Message);// às vezes não é mt bom exibir mensagem de erro assim, mas neste caso tudo bem. 
                res = false;
            }

            return res;
        }
    }
}
