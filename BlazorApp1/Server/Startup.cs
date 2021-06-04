using BlazorApp1.FakeDAL2;
using BlazorApp1.Shared.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace BlazorApp1.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<FakeDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "Test"));
        }

        private void AddTestData(FakeDbContext ctx)
        {
            Person p01 = new Person { Id = 1, Name = "Adminateachy", Login = "ateachy1" };
            Person p02 = new Person { Id = 2, Name = "Admins", Login = "mAdmins2" };
            Person p03 = new Person { Id = 3, Name = "Tiana Perkins", Login = "tper3" };
            Person p04 = new Person { Id = 4, Name = "Tony Smith", Login = "tsmith4" };
            Person p05 = new Person { Id = 5, Name = "Terry Pratchett", Login = "tpra5" };
            Person p06 = new Person { Id = 6, Name = "Tennis Court", Login = "tcourt6" };
            Person p07 = new Person { Id = 7, Name = "Styles Green", Login = "sgreen7" };
            Person p08 = new Person { Id = 8, Name = "Sandra Collins", Login = "sco8" };
            Person p09 = new Person { Id = 9, Name = "Suzy Ormond", Login = "sormo9" };
            Person p10 = new Person { Id = 10, Name = "Stella Kings", Login = "skings10" };
            Person p11 = new Person { Id = 11, Name = "Perry Johnson", Login = "pjoh11" };
            Person p12 = new Person { Id = 12, Name = "Petra Schevich", Login = "psche12" };

            ctx.Persons.Add(p01);
            ctx.Persons.Add(p02);
            ctx.Persons.Add(p03);
            ctx.Persons.Add(p04);
            ctx.Persons.Add(p05);
            ctx.Persons.Add(p06);
            ctx.Persons.Add(p07);
            ctx.Persons.Add(p08);
            ctx.Persons.Add(p09);
            ctx.Persons.Add(p10);
            ctx.Persons.Add(p11);
            ctx.Persons.Add(p12);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                var context = app.ApplicationServices.GetService<FakeDbContext>();
                AddTestData(context);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
