using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class RoomBookingConfiguration : IEntityTypeConfiguration<RoomBooking>
    {
        public void Configure(EntityTypeBuilder<RoomBooking> builder)
        {
            builder.Property(p => p.FinalPrice).HasColumnType("decimal(18,2)");
        }
    }
}