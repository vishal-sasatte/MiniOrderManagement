using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniOrderManagement.Domain.Entities;

namespace MiniOrderManagement.Infrastructure.Data.Configurations
{
    public class CustomerProfileConfiguration : IEntityTypeConfiguration<CustomerProfile>
    {
        public void Configure(EntityTypeBuilder<CustomerProfile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Address)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(p => p.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(20);
        }
    }
}
