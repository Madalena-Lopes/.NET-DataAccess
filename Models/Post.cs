using Dapper.Contrib.Extensions;
//using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Models
{
    [Table("[Post]")]
    public class Post
    {

        public Post()
            => Tags = new List<Tag>();    
        

        //1 post tem mtas tags
        //a relação de 1 para muitos e de mts para mts, em termos de código implementa-se da mesma maneira
        public int Id { get; set; }        
        
        public int CategoryId { get; set; } //o q tenho na tabela Post
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;

        [Write(false)] // não incluir no insert.
        public List<Tag> Tags { get; set; }
    }
}
