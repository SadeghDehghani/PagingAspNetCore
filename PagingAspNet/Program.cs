using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PagingAspNet.Models.Domain;
using ReflectionIT.Mvc.Paging;

namespace PagingAspNet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



           

            builder.Services.AddDbContext<DataBaseContext>
                                        (options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));



            builder.Services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap5";
                options.HtmlIndicatorDown = " <span>&darr;</span>";
                options.HtmlIndicatorUp = " <span>&uarr;</span>";
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

          

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
