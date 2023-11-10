using Microsoft.EntityFrameworkCore;
using Raizen.WebApp.CadastroClientes.Models;

namespace Raizen.WebApp.CadastroClientes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<ClienteModel> Clientes { get; set; }
    }
}
