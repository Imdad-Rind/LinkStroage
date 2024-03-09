using LinkStorage.Data;
using LinkStorage.Repository;
using LinkStorage.Repository.RepoImpl;
using LinkStorage.Services;
using LinkStorage.Services.ServicesImpl;
using Microsoft.EntityFrameworkCore;

namespace LinkStorage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            builder.Services.AddDbContextPool<LinkStorageDbContext>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddHttpClient<IApiService, ApiServiceImpl>();
            
            builder.Services.AddScoped<IApiService, ApiServiceImpl>();
            builder.Services.AddScoped<ILinkRepository, LinkRepositoryImpl>();
            builder.Services.AddScoped<ILinkService, LinkServiceImpl>();
            

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
