using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderedProductConfiguration : IEntityTypeConfiguration<OrderedProduct>
    {
        public void Configure(EntityTypeBuilder<OrderedProduct> builder)
        {
            builder.OwnsOne(p => p.ProductOrdered, o => {o.WithOwner();});
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        }
    }
}