using Blog.Models;
using Blog.Repositories;


namespace Blog.Screens.CategoryScreens
{
    public class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Apagar categoria");
            Console.WriteLine("----------------");
            Console.WriteLine("Qual o id da categoria a apagar? ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuCategoryScreen.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Categoria apagada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível apagar a categoria.");
                Console.WriteLine(ex.Message);// às vezes não é mt bom exibir mensagem de erro assim, mas neste caso tudo bem. 
            }
        }
    }
}
