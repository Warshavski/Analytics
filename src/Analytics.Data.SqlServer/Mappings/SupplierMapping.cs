using System.Data.Entity.ModelConfiguration;

using Analytics.Data.Entities;

namespace Analytics.Data.SqlServer.Mappings
{
    public class SupplierMapping : EntityTypeConfiguration<Supplier>
    {
        public SupplierMapping()
        {
            ToTable("supplier");
            HasKey(s => s.Id);

            Property(s => s.Inn)
                .HasColumnName("inn")
                .HasMaxLength(50);

            Property(s => s.ShortName)
                .HasColumnName("name_short")
                .HasMaxLength(50);

            Property(s => s.FullName)
                .HasColumnName("name_full")
                .HasMaxLength(200);
        }
    }
}
