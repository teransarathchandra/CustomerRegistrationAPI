using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistration
{
    public class DatabaseSettings
    {
        public string _DatabaseConnectionString { get; set; }
        public DatabaseSettings(string DatabaseConnectionString)
        {
            _DatabaseConnectionString = DatabaseConnectionString;
        }
    }
}
