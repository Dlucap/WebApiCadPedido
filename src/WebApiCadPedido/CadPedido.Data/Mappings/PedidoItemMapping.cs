using CadPedido.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadPedido.Data.Mappings
{
  public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
  {
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
      builder.HasKey(p => p.Id);

      builder.Property(p => p.PedidoId);

      builder.Property(p => p.ProdutoId);

      builder.Property(p => p.Quantidade)
     .HasMaxLength(36)
      .HasColumnType("int");

      builder.Property(p => p.Total)
       .HasMaxLength(36)
        .HasColumnType("decimal(5,2)");

      builder.HasOne(itmP => itmP.Pedido);

      builder.HasOne(itmP => itmP.Produto);

      builder.ToTable("pedidoItens");
    }
  }
}
