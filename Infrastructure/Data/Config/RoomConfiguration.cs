using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.Property(p => p.RoomName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.RoomDescription).IsRequired().HasMaxLength(550);
            builder.Property(p => p.RoomPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.RoomMainImageUrl).IsRequired();
        }
    }
}