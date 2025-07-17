using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Data.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Configurations.Inventory
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
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

            builder
            .HasOne(x => x.CreatedByUser)
            .WithMany(x => x.CreatedCategories)
            .HasForeignKey(x => x.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);  
            
            builder
            .HasOne(x => x.UpdatedByUser)
            .WithMany(x => x.UpdatedCategories)
            .HasForeignKey(x => x.LastModifiedBy)
            .OnDelete(DeleteBehavior.Restrict);



        }
    }
}
