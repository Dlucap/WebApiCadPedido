using CadPedido.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadPedido.Data.Mappings
{
  public class PedidoMapping : IEntityTypeConfiguration<Pedido>
  {
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
      builder.HasKey(p => p.Id);

      builder.Property(p => p.ClienteId);

      builder.Property(p => p.Total)
       .HasMaxLength(36)
        .HasColumnType("decimal(5,2)");

      builder.HasMany(p => p.PedidoItem)
             .WithOne(itm => itm.Pedido);

      builder.ToTable("pedidos");
    }
  }
}
