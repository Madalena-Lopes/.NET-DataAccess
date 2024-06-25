using Blog.Screens.UserScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.UserRoleScreens
{
    public class MenuUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular perfil/utilizador");
            Console.WriteLine("--------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Ligar utilizador/perfil");
            Console.WriteLine("2 - Remover ligação utilizador/perfil");          
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!); // A exclamação é para forçar a ter sempre uma string pq podia vir como null

            switch (option)
            {
                case 1:
                    CreateUserRoleScreen.Load();
                    break;
                case 2:
                    DeleteUserRoleScreen.Load();
                    break;                
                default: Load(); break;
            }
        }
    }
}
