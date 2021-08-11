using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Dz3Configuration
{
    public class AngularComponentConfigurationProvider : ConfigurationProvider
    {
        public string FilePath { get; set; }
        public AngularComponentConfigurationProvider(string path)
        {
            FilePath = path;
        }
        public override void Load()
        {
            var componentConfig = new Dictionary<string, string>();

            int importCounter = 0;
            int dependencyCounter = 0;
            int variableCounter = 0;

            using (FileStream fs = new FileStream(FilePath, FileMode.Open))
            {
                using (StreamReader textReader = new StreamReader(fs))
                {
                    string line;
                    while ((line = textReader.ReadLine()) != null)
                    {
                        if (line.Contains("import"))
                        {
                            importCounter++;
                            componentConfig[$"import:name{importCounter}"] = betweenStrings(line, "{", "}").Trim();
                            componentConfig[$"import:path{importCounter}"] = betweenStrings(line, "'", "'").Trim();
                        }
                       else if (line.Contains("@Component"))
                        {
                            string varLine;
                            while ((varLine = textReader.ReadLine()) != null && varLine.Contains(":"))
                            {
                                dependencyCounter++;
                                var parts = varLine.Split(":");
                                componentConfig[$"@Component:dependency{dependencyCounter}key"] = parts[0].Trim().Replace(@",", ""); ;
                                componentConfig[$"@Component:dependency{dependencyCounter}value"] = parts[1].Trim().Replace(@",", ""); ;
                            }
                        }
                        else if (line.Contains("class"))
                        {
                            componentConfig[$"componentClass:name"] = betweenStrings(line, "class ", " ").Trim();

                            string varLine;
                            while ((varLine = textReader.ReadLine()) != null && varLine.Contains("="))
                            {
                                variableCounter++;
                                var parts = varLine.Split("=");
                                componentConfig[$"componentClass:variable:var{variableCounter}key"] = parts[0].Trim()
                                    .Replace(@";", "");
                                componentConfig[$"componentClass:variable:var{variableCounter}value"] = parts[1].Trim()
                                    .Replace(@";", "");
                            }
                        }
                    }
                }
                Data = componentConfig;
            }
        }
        public string betweenStrings(string text, string start, string end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);

            if (end == "")
            {
                return (text.Substring(p1));
            }
            else
            {
                return text.Substring(p1, p2 - p1);
            }
        }
    }
}