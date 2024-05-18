using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Infrastructure.Persistence.Configurations
{
    internal class DonorPersonConfigurations : IEntityTypeConfiguration<DonorPerson>
    {
        public void Configure(EntityTypeBuilder<DonorPerson> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(x => x.Donations)
                .WithOne()
                .HasForeignKey(x => x.DonorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Address)
               .WithOne(a => a.DonorPerson)
               .HasForeignKey<Address>(a => a.DonorId) 
               .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
