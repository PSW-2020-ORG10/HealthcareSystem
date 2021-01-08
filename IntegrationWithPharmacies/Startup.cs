using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using HealthClinic.CL.DbContextModel;
using IntegrationWithPharmacies.Controllers;
using IntegrationWithPharmacies.Protos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IntegrationWithPharmacies
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment CurrentEnvironment { get; }


        public Startup(IConfiguration configuration, IWebHostEnvironment currentEnvironment)
        {
            Configuration = configuration;
            CurrentEnvironment = currentEnvironment;
        }
        private string CreateConnectionStringFromEnvironment()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "MYSQLHealtcareDB";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";
		
            return $"server={server};port={port};database={database};user={user};password={password}";
        }
	    
      private string GetCurrentStage(){
	      return Environment.GetEnvironmentVariable("STAGE") ?? "Testing";
      }
	    
      // This method gets called by the runtime. Use this method to add services to the container.
      public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers();
            
            if (GetCurrentStage().Equals("Testing") && CurrentEnvironment.IsEnvironment("Testing"))
            {
                services.AddDbContext<MyDbContext>(options =>
                    options.UseInMemoryDatabase("TestingDB").UseLazyLoadingProxies());
            }
            else
            {
               services.AddDbContext<MyDbContext>(options =>
               options.UseMySql(CreateConnectionStringFromEnvironment(),
                  builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)).UseLazyLoadingProxies());

            }

         services.AddSpaStaticFiles(options => options.RootPath = "front/dist");
            services.AddCors(options =>
                options.AddPolicy("VueCorsPolicy", builder =>
                    builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:57942")));
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,MyDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // add following statements
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "front";
                if (env.IsDevelopment())
                {
                    // Launch development server for Vue.js
                    spa.UseVueDevelopmentServer();
                }
            });
            app.UseCors("VueCorsPolicy");
        }

	private Server server;
        private void OnShutdown()
        {
            if (server != null)
            {
                server.ShutdownAsync().Wait();
            }

        }
    }
}
