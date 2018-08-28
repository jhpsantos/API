using Microsoft.Win32.SafeHandles;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime;
using System.Runtime.InteropServices;

namespace Patrimonio.Repository
{
    public class Base : IDisposable
    {
        bool disposed = false;

        protected IDbConnection connection;
        public Base()
        {
            string connectionString = @"Data Source=.\;Initial Catalog=ESXDESAFIO;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            disposed = true;
        }

        ~Base()
        {
            Dispose(false);
        }
    }
}
