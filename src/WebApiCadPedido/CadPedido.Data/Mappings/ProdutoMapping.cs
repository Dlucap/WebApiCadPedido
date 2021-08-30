using CadPedido.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadPedido.Data.Mappings
{
  public class ProdutoMapping : IEntityTypeConfiguration<Produto>
  {
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
      builder.HasKey(p => p.Id);

      builder.Property(p => p.Nome)
         .HasMaxLength(36)
          .HasColumnType("varchar(36)")
          .IsRequired();

      builder.Property(p => p.Preco)
      .HasColumnType("decimal(5,2)");

      builder.Property(p => p.Ativo)
      .HasColumnType("bit");

      builder.HasOne(prod => prod.PedidoItem)
               .WithOne(itm => itm.Produto);

      builder.ToTable("produtos");
    }
  }
}
