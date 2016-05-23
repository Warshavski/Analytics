using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Analytics.Data.Entities;  

namespace Analytics.Data.SqlServer.Mappings
{
    public class SubdivisionMapping : EntityTypeConfiguration<Subdivision>
    {
        public SubdivisionMapping()
        {
            ToTable("subdivision");
            HasKey(s => s.Id);

            Property(s => s.Id)
                .HasColumnName("id_subdivision");

            Property(s => s.UserId)
                .IsRequired()
                .HasColumnName("id_user");

            Property(s => s.Address)
                .HasColumnName("address")
                .HasMaxLength(100);

            Property(s => s.ShortName)
                .HasColumnName("name_short")
                .HasMaxLength(20);

            Property(s => s.FullName)
                .HasColumnName("name_full")
                .HasMaxLength(100);

            HasRequired<User>(s => s.User)
                .WithMany(u => u.Subdivisions)
                .HasForeignKey(s => s.UserId);
        }
    }
}
