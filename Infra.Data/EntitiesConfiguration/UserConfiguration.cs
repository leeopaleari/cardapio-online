using CardapioOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardapioOnline.Infra.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("T_USER");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd().HasColumnName("ID_USER");
        builder.Property(x => x.FirstName).HasColumnName("NM_FIRST_NAME").IsRequired().HasMaxLength(15);
        builder.Property(x => x.LastName).HasColumnName("NM_LAST_NAME").IsRequired().HasMaxLength(50);
        builder.Property(x => x.Email).HasColumnName("DS_EMAIL").HasMaxLength(60);
        builder.Property(x => x.Password).HasColumnName("DS_PASSWORD");
        builder.Property(x => x.Phone).HasColumnName("DS_PHONE").HasMaxLength(11);
        builder.Property(x => x.BirthDate).HasColumnName("DT_BIRTH_DATE");
    }
}