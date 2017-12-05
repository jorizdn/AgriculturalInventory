using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AI.BLL.Helpers;
using AI.BLL.ConfigServices;
using AI.DAL.Model;

namespace AI.Interface
{
    public class Startup
    {
        private static string _dbConnection;
        private static IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment env)
        {
            var dalfolder = PathHelper.GetParentFolder(env);

            var builder =
                new ConfigurationBuilder().SetBasePath(dalfolder)
                    .AddJsonFile($"PublishSettings\\appSettings.{env.EnvironmentName}.json", false, true);

            _configurationRoot = builder.Build();
            _dbConnection = _configurationRoot.GetConnectionString("DefaultConnection");
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCors();
            services.RegisterMvc();
            services.RegisterSwagger();
            services.RegisterSqlServer(_dbConnection);
            services.RegisterIdentities(_dbConnection);
            services.RegisterDInjections();

            services.Configure<AppSettingModel>(_configurationRoot.GetSection("SwaggerAuthentication"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
