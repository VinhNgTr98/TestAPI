using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebClient.Data;
using WebClient.Services;
using WebClient.Services.Interfaces;
namespace WebClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebClientContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WebClientContext") 
                ?? throw new InvalidOperationException("Connection string 'WebClientContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddHttpClient<BookApiService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7060/");
            });
            builder.Services.AddHttpClient<IAuthService, AuthService>();

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
