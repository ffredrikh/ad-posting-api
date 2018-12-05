using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdPostingApi.Entities;
using AdPostingApi.Models;
using AdPostingApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AdPostingApi
{
    public class Startup
    {
        public static IConfigurationRoot Cfg;


        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {   
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Cfg = builder.Build();
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IAdsRepository, AdsRepository>();
            var connstr = Cfg["ConnectionStrings:AdPostingApiConnStr"];
            services.AddDbContext<AdInfoContext>(o => o.UseSqlServer(connstr));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<AdInfo, AdInfoDto>();
                cfg.CreateMap<AdInfoDto, AdInfo>();
                cfg.CreateMap<AdPicture, AdPictureDto>();
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
