using Cecam.Domain.Entities;
using Cecam.Infra.Data.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Cecam.Infra.Data.Context
{
    public class CecamContext : DbContext
    {
        public virtual DbSet<Company> Companys { get; set; }

        public CecamContext()
            : base("Cecam")
        {
            this.Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new CompanyConfiguration());
        }
    }
}
