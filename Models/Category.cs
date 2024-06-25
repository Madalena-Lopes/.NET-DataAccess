using Dapper.Contrib.Extensions;
//using System.ComponentModel.DataAnnotations.Schema;//colocou esta por defeito, mas queria a do dapper


namespace Blog.Models
{
    [Table("[Category]")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        [Write(false)] //para não incluir no insert.
        public List<Post> Posts { get; set; }
    }
}
