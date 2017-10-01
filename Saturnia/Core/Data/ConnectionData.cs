using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class ConnectionData
    {
        private String connectionString;

        public ConnectionData()
        {
            connectionString = "Data Source=163.178.173.148;Initial Catalog=Saturnia_DB;Persist Security Info=True;User ID=lenguajes;Password=lenguajes";
        }

        public string ConnectionString { get => connectionString; }
    }
}
