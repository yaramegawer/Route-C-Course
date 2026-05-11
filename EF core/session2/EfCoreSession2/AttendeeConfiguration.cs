using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EfCoreSession2
{
    internal class AttendeeConfiguration
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.Property(a => a.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(a => a.Email)
                .IsRequired();

            // Owned Entity
            builder.OwnsOne(a => a.Address);

            // One-to-One
            builder.HasOne(a => a.Badge)
                .WithOne(b => b.Attendee)
                .HasForeignKey<Badge>(b => b.AttendeeId);
        }
    }
}
