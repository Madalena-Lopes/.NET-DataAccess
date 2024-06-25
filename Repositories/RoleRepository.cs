using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    //Substituída pela class Repository - genérica
    public class RoleRepository
    {
        private readonly SqlConnection _connection; //readonly pq não quero que ninguém a altere - mais nenhuma vez depois de atribuído no construtor

        public RoleRepository(SqlConnection connection)
            => _connection = connection;


        public IEnumerable<Role> Get()
            => _connection.GetAll<Role>();


        public Role Get(int id)
            => _connection.Get<Role>(id);

        public void Create(Role role)
        {
            role.Id = 0; //identity seed = identidade - na tabela User. esta linha é para forçar Id=0 pq se alguém tentasse inserir um id<>0 daria erro.
            _connection.Insert<Role>(role);
        }

        public void Update(Role role)
        {
            if (role.Id != 0)
                _connection.Update<Role>(role);
        }

        public void Delete(Role role)
        {
            if (role.Id != 0)
                _connection.Delete<Role>(role);
        }

        public void Delete(int id)
        {
            if (id == 0)
                return;

            var role = _connection.Get<Role>(id);
            _connection.Delete<Role>(role);
        }

    }
}
