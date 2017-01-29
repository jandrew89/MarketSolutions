using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Infrastructure.Common.ApplicationSettings.Implementations
{
    public class WebConfigConnectionStringRepository : IConnectionStringRepository
    {
        public string ReadConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
    }
}
