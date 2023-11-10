using Microsoft.EntityFrameworkCore;
using Raizen.WebApp.CadastroClientes.Data;
using Raizen.WebApp.CadastroClientes.Repositorio;

namespace Raizen.WebApp.CadastroClientes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<DataContext>(d => d.UseSqlServer(builder.Configuration.GetConnectionString("Banco")));

            builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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