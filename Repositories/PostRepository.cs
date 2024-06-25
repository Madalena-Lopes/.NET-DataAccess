using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;


namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection; //não tem como evitar de repetir. Como na classe pai!


        //: base(connection) passar a ligacção para o construtor da classe pai.
        public PostRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

        public List<Post> ReadWithTag()
        {
            var query = @"
                SELECT
                    [Post].*,
                    [Tag].*
                FROM
                    [Post]
                    LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                    LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";

            var posts = new List<Post>();
            var items = _connection.Query<Post, Tag, Post>(
                query,
                (post, tag) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;
                        if (tag != null)
                            pst.Tags.Add(tag); //se a lista não estivesse inicializada no construtor (!), aqui ia dar erro ao fazer o add role à lista de Roles
                        posts.Add(pst);
                    }
                    else
                        pst.Tags.Add(tag);

                    return pst;
                }, splitOn: "Id");

            return posts;
        }

        public List<Post> ReadWithTag(int categoryId)
        {
            var query = @"
                SELECT
                    [Post].*,
                    [Tag].*
                FROM
                    [Post]
                    LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                    LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]
                WHERE [Post].[CategoryId] = @CategoryId";

            var posts = new List<Post>();
            var items = _connection.Query<Post, Tag, Post>(
                query, 
                (post, tag) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;
                        if (tag != null)
                            pst.Tags.Add(tag); //se a lista não estivesse inicializada no construtor (!), aqui ia dar erro ao fazer o add role à lista de Roles
                        posts.Add(pst);
                    }
                    else
                        pst.Tags.Add(tag);

                    return pst;
                },  new { categoryId } , splitOn: "Id");

            return posts;
        }
    }
}
