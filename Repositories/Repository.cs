using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    //onde T seja uma class 
    //T de Type 
    //<T> para dizer que é uma class genérica: Tag, Categoria, Post, Role. Balta prefere colocar <TModel>
    public class Repository<T> where T: class 
    {
        private readonly SqlConnection _connection; //readonly pq não quero que ninguém a altere - mais nenhuma vez depois de atribuido no construtor

        public Repository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<T> Get()
            => _connection.GetAll<T>();


        public T Get(int id)
            => _connection.Get<T>(id);

        public void Create(T model)
        {
            //não tenho acesso ao .Id pq é genérico. Mas existe forma de fazer. Qd souber vir aqui e alterar!
            //model.Id = 0; //identity seed na tabela User. esta linha é para forçar Id=0 pq se alguém tentasse inserir um id<>0 daria erro.
            _connection.Insert<T>(model);
        }

        public void Update(T model)
        {
            //if (model.Id != 0)
                _connection.Update<T>(model);
        }

        public void Delete(T model)
        {
            //if (model.Id != 0)
                _connection.Delete<T>(model);
        }

        public void Delete(int id)
        {
            if (id == 0)
                return;

            var model = _connection.Get<T>(id);
            _connection.Delete<T>(model);
        }

    }
}
