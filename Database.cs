using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    //no console aplication a class estatica vai resolver o problema de não ter q estar a indicar a ligação em todo o sítio
    //mas a classe estática tem o problema de ficar sempre em memória. Nunca sai da memória.
    public static class Database
    {
        public static SqlConnection Connection;
    }
}
