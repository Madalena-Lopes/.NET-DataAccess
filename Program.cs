// See https://aka.ms/new-console-template for more information
using Blog;
using Blog.Models;
using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Screens.PostScreens;
using Blog.Screens.PostTagScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.TagScreens;
using Blog.Screens.UserRoleScreens;
using Blog.Screens.UserScreens;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Net.WebSockets;
using static System.Net.Mime.MediaTypeNames;

const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
Console.WriteLine("Hello, World!");
//ReadUsers();
//ReadUser();
//CreateUser();
//UpdateUser();
//DeleteUser();

//var connection1 = new SqlConnection(CONNECTION_STRING);
//connection1.Open();
//ReadUsers1(connection1); //a partilhar a mesma ligação SQL
//ReadRoles1(connection1);
//ReadUsers2(connection1);
//ReadUsersWithRoles(connection1);
//ReadRoles2(connection1);
//ReadTags2(connection1);
//UpdateUser2(connection1);
//DeleteUser2(connection1);
//ReadUser1();
//CreateUser1();
//UpdateUser1();
//DeleteUser1();
//connection1.Close();

Database.Connection = new SqlConnection(CONNECTION_STRING);
Database.Connection.Open();

Load();

Console.ReadKey();
Database.Connection.Close();

#region Desafio
static void Load()
{
    Console.Clear();
    Console.WriteLine("Meu Blog");
    Console.WriteLine("-----------------");
    Console.WriteLine("O que deseja fazer?");
    Console.WriteLine();
    Console.WriteLine("1 - Gestão de utilizadores");
    Console.WriteLine("2 - Gestão de perfis");
    Console.WriteLine("3 - Gestão de categorias");
    Console.WriteLine("4 - Gestão de tags");
    Console.WriteLine("5 - Gestão de Publicações");
    Console.WriteLine("6 - Vincular perfil/utilizador");
    Console.WriteLine("7 - Vincular post/tag");
    Console.WriteLine("8 - Relatórios");
    Console.WriteLine();
    Console.WriteLine();
    var option = short.Parse(Console.ReadLine()!);

    switch (option)
    {
        case 1:
            MenuUserScreen.Load();
            break;
        case 2:
            MenuRoleScreen.Load();
            break;
        case 3:
            MenuCategoryScreen.Load();
            break;
        case 4:
            MenuTagScreen.Load();
            break;
        case 5:
            MenuPostScreen.Load();
            break;
        case 6:
            MenuUserRoleScreen.Load();
            break;
        case 7:
            MenuPostTagScreen.Load();
            break;
        default: Load(); break;
    }
}


#endregion

static void ReadUsers() //GetAll do dapper já trás todos os campos Mas existem caso que teremos que fazer querys. Por outro lado ali tb deve trazer todos os campos sem precisar...
{
    using (var connection = new SqlConnection(CONNECTION_STRING))
    {        
        var users = connection.GetAll<User>();

        foreach (var user in users) 
        { 
            Console.WriteLine(user.Name);
        }
    }
}
static void ReadUsers1(SqlConnection connection) 
{
    var repository = new UserRepository(connection);
    var users = repository.Get();
    foreach (var user in users)
        Console.WriteLine(user.Name);    
}

static void ReadUsers2(SqlConnection connection)
{
    var repository = new Repository<User>(connection);
    var items = repository.Get();

    foreach (var item in items)
    { 
        Console.WriteLine(item.Name);
        foreach (var role in item.Roles)
            Console.WriteLine($" - {role.Name}"); //Não consegue ler os roles
    }
}

//como ReadUsers2 não consegue ler os roles, temos esta versão para o fazer
static void ReadUsersWithRoles(SqlConnection connection)
{
    var repository = new UserRepository(connection);
    var items = repository.ReadWithRole();

    foreach (var item in items)
    {
        Console.WriteLine(item.Name);
        foreach (var role in item.Roles)
            Console.WriteLine($" - {role.Name}"); //e agora já consegue
    }
}

static void ReadRoles1(SqlConnection connection)
{
    var repository = new RoleRepository(connection);
    var roles = repository.Get();
    
    foreach (var role in roles)
        Console.WriteLine(role.Name);
}

static void ReadRoles2(SqlConnection connection)
{
    var repository = new Repository<Role>(connection);
    var items = repository.Get();

    foreach (var item in items)
        Console.WriteLine(item.Name);
}

static void ReadTags2(SqlConnection connection)
{
    var repository = new Repository<Tag>(connection);
    var items = repository.Get();

    foreach (var item in items)
        Console.WriteLine(item.Name);
}

static void ReadUser() //GetAll do dapper já trás todos os campos. Mas existem casos que teremos que fazer querys. Por outro lado ali tb deve trazer todos os campos sem precisar...
{
    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        var user = connection.Get<User>(1);       
        Console.WriteLine(user.Name);        
    }
}

static void CreateUser() //GetAll do dapper já trás todos os campos Mas existem caso que teremos que fazer querys. Por outro lado ali tb deve trazer todos os campos sem precisar...
{
    var user = new User()
    {
        Name = "Equipa balta.io",
        Email = "hello@balta.io",
        PasswordHash = "HASH",
        Bio = "Equipa balta.io",
        Image = "https://...",
        Slug ="equipe-balta"
    };

    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        connection.Insert<User>(user);
        Console.WriteLine("Utilizador criado com sucesso!");
    }
}

static void UpdateUser() //GetAll do dapper já trás todos os campos Mas existem caso que teremos que fazer querys. Por outro lado ali tb deve trazer todos os campos sem precisar...
{
    var user = new User()
    {
        Id = 2,
        Name = "Equipa de suporte balta.io",
        Email = "hello@balta.io",
        PasswordHash = "HASH",
        Bio = "Equipa | balta.io",
        Image = "https://...",
        Slug = "equipe-balta"
    };

    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        connection.Update<User>(user);
        Console.WriteLine("Utilizador atualizado com sucesso!");
    }
}

static void DeleteUser() //GetAll do dapper já trás todos os campos Mas existem caso que teremos que fazer querys. Por outro lado ali tb deve trazer todos os campos sem precisar...
{      
    using (var connection = new SqlConnection(CONNECTION_STRING))
    {
        var user = connection.Get<User>(2);
        connection.Delete<User>(user);
        Console.WriteLine("Utilizador apagado com sucesso!");
    }
}

#region Repositório Genérico
static void CreateUser2(SqlConnection connection) //GetAll do dapper já trás todos os campos Mas existem caso que teremos que fazer querys. Por outro lado ali tb deve trazer todos os campos sem precisar...
{
    var user = new User()
    {
        Name = "Equipa balta.io",
        Email = "hello@balta.io",
        PasswordHash = "HASH",
        Bio = "Equipa balta.io",
        Image = "https://...",
        Slug = "equipe-balta"
    };

    var repository = new Repository<User>(connection);
    repository.Create(user);
    Console.WriteLine("Utilizador criado com sucesso!");
}

static void UpdateUser2(SqlConnection connection) //GetAll do dapper já trás todos os campos Mas existem caso que teremos que fazer querys. Por outro lado ali tb deve trazer todos os campos sem precisar...
{
    var user = new User()
    {
        Id = 1002,
        Name = "Equipa de suporte balta.io",
        Email = "hello@balta.io",
        PasswordHash = "HASH",
        Bio = "Equipa | balta.io",
        Image = "https://...",
        Slug = "equipe-balta"
    };

    connection.Update<User>(user);
    Console.WriteLine("Utilizador atualizado com sucesso!");
}

static void DeleteUser2(SqlConnection connection) 
{
        var user = connection.Get<User>(1008);
        connection.Delete<User>(user);
        Console.WriteLine("Utilizador apagado com sucesso!");
}

#endregion