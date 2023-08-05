using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Id).IsRequired();
        builder.Property(b => b.Name).IsRequired()
            .HasMaxLength(100);
        builder.Property(b => b.Price).HasColumnType("decimal(18,2)");
    }
}