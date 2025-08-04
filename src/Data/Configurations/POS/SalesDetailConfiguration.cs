using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Data.Entities.POS;

namespace POS.Data.Configurations.POS
{
    public class SalesDetailConfiguration : IEntityTypeConfiguration<SalesDetail>
    {
        public void Configure(EntityTypeBuilder<SalesDetail> builder)
        {
            builder
            .HasOne(x => x.Sales)
            .WithMany(x => x.SalesDetails)
            .HasForeignKey(x => x.SalesId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
            .HasOne(x => x.Product)
            .WithMany(x => x.SalesDetails)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
