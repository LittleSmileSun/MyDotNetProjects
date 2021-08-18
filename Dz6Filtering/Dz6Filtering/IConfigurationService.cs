using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Dz6Filtering
{
    public interface IConfigurationService
    {
        IConfiguration Configuration { get; set; }
    }
}
