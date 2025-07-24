using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using POS.Data.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Configurations.Inventory
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

            builder
            .HasIndex(x => x.Name)
            .IsUnique();

            builder
            .Property(x => x.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            builder /*For relational mapping*/
            .HasOne(x => x.CreatedByUser)
            .WithMany(x => x.CreatedProducts)
            .HasForeignKey(x => x.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);

            builder/*For relational mapping*/
            .HasOne(x => x.UpdatedByUser)
            .WithMany(x => x.UpdatedProducts)
            .HasForeignKey(x => x.LastModifiedBy)
            .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.SubCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
