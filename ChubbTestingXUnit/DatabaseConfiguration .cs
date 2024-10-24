using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChubbTestingXUnit
{
    public class DatabaseConfiguration
    {
        public string ConnectionString { get; set; }
    }
    public class CustomerService
    {
        private readonly DatabaseConfiguration _configuration;
        public CustomerService(IOptions<DatabaseConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }
        public string GetConnectionString() => _configuration.ConnectionString;
    }
}
