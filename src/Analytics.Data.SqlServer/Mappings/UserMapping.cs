using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using Analytics.Data.Entities;

namespace Analytics.Data.SqlServer.Mappings
{
    public class UserMapping : EntityTypeConfiguration<User>  
    {
        public UserMapping()
        {
            ToTable("user");
            HasKey(u => u.Id);
            
            Property(u => u.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("id_user");

            Property(u => u.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(100);

            Property(u => u.Login)
                .IsRequired()
                .HasColumnName("login")
                .HasMaxLength(50);

            Property(u => u.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasMaxLength(30);
        }
    }
}
