using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Win32.SafeHandles;
using Patrimonio.Entities;
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
        }

        public Base(IConfiguration settings)
        {
            connection =
               new SqlConnection(settings.GetSection("ApplicationSettings").GetSection("ConnectionString").Value);
        }

        public void SetConfiguration(IOptions<AppSettings> config)
        {
            string connectionString = config.Value.ConnectionString;
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
