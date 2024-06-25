//using System.ComponentModel.DataAnnotations.Schema; //colocou esta por defeito, mas queria a do dapper
using Dapper.Contrib.Extensions;
using System.Xml.Linq;

namespace Blog.Models
{
    [Table("[User]")] //nota��o ou metadados: o dapper em termos de tabelas queria assumir a tabela no plurar Users, mas � apenas User e por isso � q precisei desta anota��o. Tenho q colocar entre [] por User ser palavra reservada
    public class User
    {
        public User()
            => Roles = new List<Role>(); //para nunca acontecer adicionar 1 lista de roles e a lista estar vazia
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }


        [Write(false)] //para n�o incluir os perfis(Roles) na hora de os criar/gravar - n�o incluir no insert.
        public List<Role> Roles { get; set; } //1 user pode ter mts roles = perfis [UserRole] -> rela��o de muitos para muitos; Podia fazer sentido ter antes na Role.cs uma List<User>. Ou at� mesmo as 2 vis�es.
    }
}