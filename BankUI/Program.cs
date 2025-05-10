using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BankData;

namespace BankUI
{
    public class Program
    {
        /// <summary>
        /// Главен метод на приложението, който се изпълнява при стартиране.
        /// </summary>
        /// <param name="args">Аргументи от командния ред.</param>
        public static void Main(string[] args)
        {
            // Builder
            /// <summary>
            /// Създава и конфигурира WebApplicationBuilder.
            /// </summary>
            var builder = WebApplication.CreateBuilder(args);

            /// <summary>
            /// Добавя поддръжка за Razor Pages.
            /// </summary>
            builder.Services.AddRazorPages();

            /// <summary>
            /// Регистрира DbContext за работа с базата данни.
            /// </summary>
            builder.Services.AddDbContext<BankData.BankContext>();

            // App
            /// <summary>
            /// Създава и конфигурира WebApplication.
            /// </summary>
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            /// <summary>
            /// Конфигурира обработката на грешки за различни среди.
            /// </summary>
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            /// <summary>
            /// Активира обслужването на статични файлове.
            /// </summary>
            app.UseStaticFiles();

            /// <summary>
            /// Конфигурира маршрутизацията на заявките.
            /// </summary>
            app.UseRouting();

            /// <summary>
            /// Активира авторизацията.
            /// </summary>
            app.UseAuthorization();

            /// <summary>
            /// Картира Razor Pages.
            /// </summary>
            app.MapRazorPages();

            /// <summary>
            /// Настройва локализацията на заявките на "bg-BG".
            /// </summary>
            app.UseRequestLocalization("bg-BG");

            // Run
            /// <summary>
            /// Стартира приложението.
            /// </summary>
            app.Run();
        }
    }
}
