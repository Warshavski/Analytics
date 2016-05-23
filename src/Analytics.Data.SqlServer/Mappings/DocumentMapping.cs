using System.Data.Entity.ModelConfiguration;

using Analytics.Data.Entities;

namespace Analytics.Data.SqlServer.Mappings
{
    public class DocumentMapping : EntityTypeConfiguration<Document>
    {
        public DocumentMapping()
        {
            ToTable("document");
            HasKey(d => d.Id);

            Property(d => d.Id)
                .HasColumnName("id_document");

            Property(d => d.SupplierId)
              .HasColumnName("id_supplier");
            HasRequired<Supplier>(d => d.Supplier)
                .WithMany(u => u.Documents)
                .HasForeignKey(s => s.SupplierId);

            Property(d => d.SubdivisionId)
                .HasColumnName("id_subdivision");
            HasRequired<Subdivision>(d => d.Subdivision)
               .WithMany(u => u.Documents)
               .HasForeignKey(s => s.SubdivisionId);
            
            Property(d => d.CreateDate)
                .IsRequired()
                .HasColumnName("date_create");

            Property(d => d.EditDate)
                .HasColumnName("date_edit");

            Property(d => d.PayDate)
                .HasColumnName("date_pay");

            Property(d => d.PayFactDate)
                .HasColumnName("date_payfact");

            Property(d => d.DelayDays)
                .HasColumnName("days_delay");

            Property(d => d.SumNdsPrice)
                .HasColumnName("price_sum_nds");

            Property(d => d.SumOrderPrice)
                .HasColumnName("price_sum_order");

            Property(d => d.SumRetailPrice)
                .HasColumnName("price_sum_retail");

            Property(d => d.SumDiscount)
                .HasColumnName("price_sum_discount");

            Property(d => d.Comment)
                .HasColumnName("comment")
                .HasMaxLength(255);
        }
    }
}
