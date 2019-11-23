using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;

namespace CardFitness
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(86400);
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = "CardFitness";
            });


            services.AddMvc()
                .AddSessionStateTempDataProvider();
            services.AddSession();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
                options.AutomaticAuthentication = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                HttpHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                HttpHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "text/plain";
                await context.HttpContext.Response.WriteAsync(
                      "Codigo de status da pagina, status code: " +
                    context.HttpContext.Response.StatusCode);
            });


            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //    name: "login",
                //    template: "{controller=Login}/{action=Index}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");

            });
        }

    }
    public static class HttpHelper
    {
        private static IHttpContextAccessor _accessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _accessor = httpContextAccessor;
        }

        public static HttpContext HttpContext => _accessor.HttpContext;
    }
}
