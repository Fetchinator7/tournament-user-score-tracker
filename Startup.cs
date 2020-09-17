using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using tournament_user_score_tracker.Models;
using tournament_user_score_tracker.Services;
using System;

namespace tournament_user_score_tracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DotNetEnv.Env.Load();
            string CONNECTION_STRING = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            string USERS_COLLECTION_NAME = Environment.GetEnvironmentVariable("USERS_COLLECTION_NAME");
            string DATABASE_NAME = Environment.GetEnvironmentVariable("DATABASE_NAME");

            if (CONNECTION_STRING == null)
            {
                throw new Exception("Remote Mongodb connection string not found.");
            }
            if (USERS_COLLECTION_NAME == null)
            {
                throw new Exception("Remote Mongodb user collection string not found.");
            }
            if (DATABASE_NAME == null)
            {
                throw new Exception("Remote Mongodb database name string not found.");
            }

            services.Configure<MongodbDatabaseSettings>(
                Configuration.GetSection(nameof(MongodbDatabaseSettings)));

            services.AddSingleton<MongodbDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<MongodbDatabaseSettings>>().Value);

            services.AddSingleton<UserService>();

            services.AddControllers()
            .AddNewtonsoftJson(options => options.UseMemberCasing());
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
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
