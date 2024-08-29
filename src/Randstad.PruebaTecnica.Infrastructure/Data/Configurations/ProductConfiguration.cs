using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Randstad.PruebaTecnica.Domain.Entity;
using Randstad.PruebaTecnica.Domain.Utils;

namespace Randstad.PruebaTecnica.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(h => h.ProductId);
            builder.Property(e => e.Name).HasMaxLength(ProductValuesConfiguration.NameMaximumLength).HasColumnType("varchar");
            builder.Property(e => e.Description).HasMaxLength(ProductValuesConfiguration.DescriptionMaximumLength).HasColumnType("varchar");
            builder.Property(p => p.Price).HasColumnType("decimal(10,2)");
            builder.Property(p => p.Date_Insert).IsRequired().HasDefaultValue(DateTime.Now);
        }
    }
}
