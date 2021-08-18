using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Dz6Filtering
{
    public class ConfigurationService : IConfigurationService
    {
        public IConfiguration Configuration { get; set; }
        public ConfigurationService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
