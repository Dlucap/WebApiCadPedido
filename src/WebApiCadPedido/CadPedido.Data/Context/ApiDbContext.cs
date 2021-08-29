using CadPedido.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CadPedido.Data.Context
{
  public class ApiDbContext : DbContext
  {
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base (options)    {    }

    #region DBSet
    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<PedidoItem> PedidoItem { get; set; }
    public DbSet<Produto> Produto { get; set; }
    #endregion DBSet

    protected override void OnModelCreating(ModelBuilder builder)
    {
      foreach (var property in builder.Model.GetEntityTypes()
          .SelectMany(e => e.GetProperties()
              .Where(p => p.ClrType == typeof(string))))
        property.SetColumnType("varchar(100)");

      builder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);

      foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

      base.OnModelCreating(builder);
    }
  }
}
