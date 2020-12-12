using FluentValidation.AspNetCore;
using HealthClinic.CL.DbContextModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatientWebApplication.Validators;

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

            if (CurrentEnvironment.IsEnvironment("Testing"))
            {
                services.AddDbContext<MyDbContext>(options =>
                    options.UseInMemoryDatabase("TestingDB").UseLazyLoadingProxies());
            }
            else
            {
                services.AddDbContext<MyDbContext>(options =>
                options.UseMySql(ConfigurationExtensions.GetConnectionString(Configuration, "MyDbContextConnectionString")).UseLazyLoadingProxies());
            }

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
