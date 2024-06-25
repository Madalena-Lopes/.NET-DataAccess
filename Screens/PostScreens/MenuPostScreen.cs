using Blog.Screens.UserScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.PostScreens
{
    public class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Posts");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar pots");
            Console.WriteLine("2 - Inserir post");
            Console.WriteLine("3 - Atualizar post");
            Console.WriteLine("4 - Apagar post");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!); // A exclamação é para forçar a ter sempre uma string pq podia vir como null

            switch (option)
            {
                case 1:
                    ListPostsScreen.Load();
                    break;
                case 2:
                    CreatePostScreen.Load();
                    break;
                case 3:
                    UpdatePostScreen.Load();
                    break;
                case 4:
                    DeletePostScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
