﻿using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repositories
{
    //public class UserRepository
    //{
    //    private readonly SqlConnection _connection; //readonly pq não quero que ninguém a altere - mais nenhuma vez depois de atribuído no construtor

    //    public UserRepository(SqlConnection connection)
    //        => _connection = connection;
        

    //    // ReadUsers() //GetAll do dapper já trás todos os campos Mas existem caso que teremos que fazer querys. Por outro lado ali tb deve trazer todos os campos sem precisar...                     
    //    public IEnumerable<User> Get() 
    //        => _connection.GetAll<User>();                          
        

    //    public User Get(int id)                    
    //        => _connection.Get<User>(id);
        

    //    public void Create(User user)
    //    {
    //        user.Id = 0; //identity seed = identidade - na tabela User. esta linha é para forçar Id=0 pq se alguém tentasse inserir um id<>0 daria erro.
    //        _connection.Insert<User>(user);
    //    }

    //    public void Update(User user)
    //    { 
    //        if (user.Id != 0)
    //            _connection.Update<User>(user);
    //    }

    //    public void Delete(User user)
    //    {
    //        if (user.Id != 0)
    //            _connection.Delete<User>(user);
    //    }

    //    public void Delete(int id)
    //    {
    //        if (id == 0)
    //            return;

    //        var user = _connection.Get<User>(id);    
    //        _connection.Delete<User>(user);
    //    }

    //}
}
