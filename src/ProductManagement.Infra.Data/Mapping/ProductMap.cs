using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Infra.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Description)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar(255)");

            builder.Property(prop => prop.Status)
               .HasColumnName("Status")
               .HasColumnType("bit");

            builder.Property(prop => prop.ManufacturingDate)
                .IsRequired()
                .HasColumnName("ManufacturingDate")
                .HasColumnType("datetime");

            builder.Property(prop => prop.ExpirationDate)
                .HasColumnName("ExpirationDate")
                .HasColumnType("datetime");

            builder.Property<int?>("ProviderId")
                .HasColumnName("Provider_Id");
        }
    }
}
