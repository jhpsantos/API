using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime;

namespace Patrimonio.Repository
{
    public class Base : IDisposable
    {
        protected IDbConnection connection;
        public Base()
        {
            string connectionString = @"Data Source=.\;Initial Catalog=ESXDESAFIO;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
