using EventStore.EventDBContext;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientWebApplication.Validators;
using System;

namespace PatientWebApplication
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

        private string CreateConnectionStringFromEnvironmentEventStore()
        {
            string server = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? "3306";
            string database = Environment.GetEnvironmentVariable("DATABASE_SCHEMA") ?? "EventsDB";
            string user = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? "root";
            string password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? "root";

            return $"server={server};port={port};database={database};user={user};password={password}";

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidationFilter());
            })
           .AddFluentValidation(options =>
           {
               options.RegisterValidatorsFromAssemblyContaining<Startup>();
           });

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

                services.AddDbContext<EventDbContext>(options =>
                options.UseMySql(CreateConnectionStringFromEnvironmentEventStore(),
                   builder => builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)).UseLazyLoadingProxies());
            }

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MyDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseOcelot().Wait();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOcelot().Wait();
        }
    }
}
