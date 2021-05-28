using EmployeeManager.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManager
{
    public class Startup
    {
        //permet de recuperer les valeurs contenues dans le fichier appsetting.Json
        // variable et constructeur ajoutés
        private IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //string serveurBD = @"server=localdb;userid=root;password=;database= EmplManagerDB";
            //using var connection = new MySqlConnection(serveurBD);

            services.AddDbContextPool<EmplManagerDbContext>(
                options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            // Ajout du service qui nous permet de manager l'utilisateur en cours
            // une sorte de Log de l'utilisateur en cours
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<EmplManagerDbContext>();

            // ajoute du service MVC au projet
            services.AddMvc().AddXmlDataContractSerializerFormatters().AddMvcOptions( option =>
            {
                option.EnableEndpointRouting = false; 
            });

            // permet de rendre un service injectable. on peut aussi utiliser (services.AddTransient et services.AddScoped)
            services.AddScoped<IEmployeeServices,SQLEmployeeServices>();
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
                // permet de capturer les erreurs venant des requettes http
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                //app.UseStatusCodePages();
            }

            //ce middleWeare meth recupere toutes les requette ayant pour cible des fichier dans wwwroot
            //NB: il doit etre le premier MiddleWeare a etre appele
            app.UseStaticFiles();

            //******* ce Middlewear configure le model MVC par defaut( avec comme route {controller = Home}/{action = index}/{id?})
            //app.UseMvcWithDefaultRoute();

            //*** ce MiddleWare le model MVC En specifiant le model de route que l<on souhaite utiliser
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //*** Ici on Specifie un model MVC Sans routes
            app.UseMvc();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                   //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                });
            });
        }
    }
}
