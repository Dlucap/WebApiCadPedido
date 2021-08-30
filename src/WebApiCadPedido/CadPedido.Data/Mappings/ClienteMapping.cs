using CadPedido.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadPedido.Data.Mappings
{
  public class ClienteMapping : IEntityTypeConfiguration<Cliente>
  {
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
      builder.HasKey(p => p.Id);

      builder.Property(p => p.Nome)
         .HasMaxLength(80)
          .HasColumnType("varchar(80)");

      builder.ToTable("clientes");
    }
  }
}
