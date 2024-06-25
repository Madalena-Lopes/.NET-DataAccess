using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.TagScreens
{
    //tudo estático pq é só desenho
    public static class MenuTagScreen 
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de tags");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar tags");
            Console.WriteLine("2 - Inserir tag");
            Console.WriteLine("3 - Atualizar tag");
            Console.WriteLine("4 - Apagar tag");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!); // A exclamação é para forçar a ter sempre uma string pq podia vir como null

            switch (option)
            {
                case 1:
                    ListTagsScreen.Load();
                    break;
                case 2: 
                    CreateTagScreen.Load(); 
                    break;
                case 3:
                    UpdateTagScreen.Load();
                    break;
                case 4:
                    DeleteTagScreen.Load();
                    break;
                default: Load(); break;
            }
        }
    }
}
