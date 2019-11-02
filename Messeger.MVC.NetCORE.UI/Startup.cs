using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Messeger.BLL.Interfaces.Services;
using Messeger.BLL.Services;
using Messeger.DAL;
using Messeger.DAL.Interfaces;
using Messeger.DAL.Repositories;
using Messeger.MVC.NetCORE.UI.FilterAttribute;
using Messeger.MVC.NetCORE.UI.Validations.API;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Messeger.MVC.NetCORE.UI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<Messeger_DBContext>(option => option.UseSqlServer(Configuration.GetConnectionString("MessengerDB")));
            services.AddSession();
            services.AddMvc();
            services.AddSingleton<MemberAttribute>();
            services.AddSingleton<MemberAttribute>();
            services.AddHttpContextAccessor();
            services.AddScoped<IApiValidation, ApiValidation>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<EF_IMemberRepository, EF_MemberRepository>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
          
            app.UseStaticFiles(new StaticFileOptions
            {
             FileProvider = new PhysicalFileProvider(
             Path.Combine(Directory.GetCurrentDirectory(), "Content")),
                RequestPath = "/Content"
            });
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
