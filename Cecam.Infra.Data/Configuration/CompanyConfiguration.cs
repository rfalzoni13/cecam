using Cecam.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Cecam.Infra.Data.Configuration
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            HasKey(c => c.Id).Property(c => c.Id).HasColumnOrder(1);

            Property(c => c.CompanyName).IsRequired().HasMaxLength(500).HasColumnOrder(2);

            Property(c => c.DocumentNumber).IsRequired().HasMaxLength(50).HasColumnOrder(3);

            Property(c => c.PhoneNumber).IsRequired().HasMaxLength(50).HasColumnOrder(4);

            Property(c => c.Active).IsRequired().HasColumnOrder(5);

            Property(c => c.Created).IsRequired().HasColumnOrder(6);

            Property(c => c.Modified).IsOptional().HasColumnOrder(7);
        }
    }
}
