using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Dz3Configuration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder();

            builder.AddJsonFile("catconfig.json");
            builder.AddTextFile("app.component.ts");

            var newConfiguration = builder.Build();

            int importCounter = 0;
            foreach (var item in newConfiguration.GetSection("import").GetChildren())
            {
                importCounter++;
                Console.WriteLine($"import key №{importCounter}: {item.Key}" + " -- " + 
                    $"import value №{ importCounter}: { item.Value}\n");
            }
            Console.WriteLine("");

            int dependencyCounter = 0;
            foreach (var item in newConfiguration.GetSection("@Component").GetChildren())
            {
                dependencyCounter++;
                Console.WriteLine($"classdependency key №{dependencyCounter}: {item.Key}" + " -- " +
                   $"classdependency value №{ dependencyCounter}: { item.Value}\n");
            }
            Console.WriteLine("");

            int classNameCounter = 0;
            var nameSection = newConfiguration.GetSection("componentClass").GetSection("name");
            if (nameSection != null)
            {
                classNameCounter++;
                Console.WriteLine($"className key №{classNameCounter}: {nameSection.Key}" + " -- " +
                   $"className value №{ classNameCounter}: { nameSection.Value}\n");
            }
            Console.WriteLine("");

            int variableCounter = 0;
            if (newConfiguration.GetSection("componentClass").GetSection("variable") != null)
            {
                foreach (var subitem in newConfiguration.GetSection("componentClass").GetSection("variable").GetChildren())
                {
                    variableCounter++;
                    Console.WriteLine($"varible key №{variableCounter}: {subitem.Key}" + " -- " +
                   $"varible value №{ variableCounter}: { subitem.Value}\n");
                }
            }

            // Котики

            services.Configure<Cat>(newConfiguration);
            services.Configure<Cat>(opt =>
            {
                opt.Age = 5;
            });

            // Angular

            var angularComponentCongif = new AngularComponentConfigClass();
            newConfiguration.Bind(angularComponentCongif);

            services.AddSingleton<IConfiguration>(newConfiguration);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dz3Configuration", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<CatMiddleware>();
        }
    }
}
