using CardapioOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioOnline.Infra.Data.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("T_PRODUCT");

        builder.HasKey(p => p.Code);
        builder.Property(p => p.Code).ValueGeneratedNever();
        builder.Property(p => p.Code).IsRequired();
        builder.Property(p => p.Name).HasMaxLength(30).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(60);
        builder.Property(p => p.CostValue).HasPrecision(18, 2).IsRequired();
        builder.Property(p => p.SellValue).HasPrecision(18, 2).IsRequired();
    }
}