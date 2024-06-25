using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.RoleScreens
{
    public static class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de perfis");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar perfis");
            Console.WriteLine("2 - Inserir perfil");
            Console.WriteLine("3 - Atualizar perfil");
            Console.WriteLine("4 - Apagar perfil");
            Console.WriteLine();
            Console.WriteLine();
            
            var option = short.Parse(Console.ReadLine()!); // A exclamação é para forçar a ter sempre uma string pq podia vir como null

            switch (option)
            {
                case 1:
                    ListRolesScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    UpdateRoleScreen.Load();
                    break;
                case 4:
                    DeleteRoleScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
