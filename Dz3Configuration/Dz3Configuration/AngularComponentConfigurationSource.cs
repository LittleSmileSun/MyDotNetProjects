using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Dz3Configuration
{
    public class AngularComponentConfigurationSource : IConfigurationSource
    {
        public string FilePath { get; private set; }
        public AngularComponentConfigurationSource(string filename)
        {
            FilePath = filename;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            // получаем полный путь для файла
            string filePath = builder.GetFileProvider().GetFileInfo(FilePath).PhysicalPath;
            return new AngularComponentConfigurationProvider(filePath);
        }
    }
}
