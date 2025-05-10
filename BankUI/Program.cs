using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BankData;

namespace BankUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Builder
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<BankData.BankContext>();

            // App
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseRequestLocalization("bg-BG");
            // Run
            app.Run();
        }
    }
}
