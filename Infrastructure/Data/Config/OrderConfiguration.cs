using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

/// <summary>
/// Migration configuration for order entity
/// </summary>
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasMany(o => o.OrderItems)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}