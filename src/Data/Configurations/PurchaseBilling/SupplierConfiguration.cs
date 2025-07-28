using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Data.Entities.PurchaseBilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Configurations.PurchaseBilling
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
           builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.ContactPerson)
                .HasMaxLength(100);

            builder
                .Property(x => x.ContactNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder
                .Property(x => x.EmailAddress)
                .HasMaxLength(150);

            builder
                .Property(x => x.Address)
                .HasMaxLength(500);

            builder
                .HasIndex(x => new { x.Name, x.ContactNumber })
                .IsUnique();

            builder
                .Property(x => x.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            builder
                .HasOne(x => x.CreatedByUser)
                .WithMany(x => x.CreatedSuppliers)
                .HasForeignKey(x => x.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.UpdatedByUser)
                .WithMany(x => x.UpdatedSuppliers)
                .HasForeignKey(x => x.LastModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
