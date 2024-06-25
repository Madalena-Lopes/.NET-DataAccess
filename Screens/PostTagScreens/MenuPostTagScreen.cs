using Blog.Screens.UserRoleScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.PostTagScreens
{
    public class MenuPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Vincular Post/Tag");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Ligar Post/Tag");
            Console.WriteLine("2 - Remover ligação Post/Tag");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!); // A exclamação é para forçar a ter sempre uma string pq podia vir como null

            switch (option)
            {
                case 1:
                    CreatePostTagScreen.Load();
                    break;
                case 2:
                    DeletePostTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
