using Data.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Services;
using Web.Authentication;

namespace Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseRewriter(new RewriteOptions().AddRedirectToHttps());
            }

            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(ConfigureRoutes);
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            ConfigureServicesCommon(services);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureServicesCommon(services);
            ConfigureSSL(services);
        }

        private void ConfigureServicesCommon(IServiceCollection services)
        {
            ConfigureAuthentication(services);

            services.AddTransient<UserService, UserService>();
            services.AddTransient<AuthService, AuthService>();

            services.AddDbContext<ApplicationUserContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SQLDatabase")));

            services.AddSession();
            services.AddMvc();
        }

        private void ConfigureSSL(IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            var identityBuilder = services.AddIdentity<ApplicationUser, ApplicationRole>(
                    identityOptions =>
                    {
                        identityOptions.Password.RequireDigit = false;
                        identityOptions.Password.RequireUppercase = false;
                        identityOptions.Password.RequireNonAlphanumeric = false;
                        identityOptions.User.RequireUniqueEmail = true;
                        identityOptions.SignIn.RequireConfirmedEmail = false;
                        identityOptions.SignIn.RequireConfirmedPhoneNumber = true;
                    })
                .AddEntityFrameworkStores<ApplicationUserContext>();



            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ApplicationUserClaimsPrincipalFactory>();
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(
                "Default",
                "{controller=Home}/{action=Index}");
        }
    }
}
