using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portal.Infrastructure;
using Infrastructure.Dapper;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Portal
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
            services.AddMvc();

            CookieOptions cookieOptions = new CookieOptions();
            Configuration.GetSection("CookieOptions").Bind(cookieOptions);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.Cookie.Domain = cookieOptions.Domain;
                options.Cookie.Name = cookieOptions.Name;
                options.Cookie.Path = cookieOptions.Path;
            });

            services.AddDapper(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("SqlServerConnectionString");
                options.DatabaseType = DatabaseType.SQLServer;
            });

            ServiceConfig.RegisterService(Configuration, services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                RouteConfig.RegisterRoutes(routes);
            });
        }
    }
}
