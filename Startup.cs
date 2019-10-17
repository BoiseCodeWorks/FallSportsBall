using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CanadianSportsball.Repositories;
using CanadianSportsball.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace CanadianSportsball
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
            //ADD USER AUTH through JWT
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.Events.OnRedirectToLogin = (context) =>
                      {
                          context.Response.StatusCode = 401;
                          return Task.CompletedTask;
                      };
                });

            services.AddControllers();

            //CONNECT TO DB
            services.AddScoped<IDbConnection>(x => CreateDbConnection());

            //NOTE REGISTER SERVICES
            services.AddTransient<AccountsService>();
            services.AddTransient<AccountsRepository>();
            services.AddTransient<PlayersService>();
            services.AddTransient<PlayersRepository>();
            services.AddTransient<TeamsService>();
            services.AddTransient<TeamsRepository>();
            // services.AddTransient<GamesService>();
            // services.AddTransient<GamesRepository>();
        }

        private IDbConnection CreateDbConnection()
        {
            string connectionString = Configuration.GetSection("db").GetValue<string>("gearhost");
            return new MySqlConnection(connectionString);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
