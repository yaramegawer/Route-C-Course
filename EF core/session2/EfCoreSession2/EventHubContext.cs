using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace EfCoreSession2
{
    public class EventHubContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }

        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        public DbSet<Badge> Badges { get; set; }

        public DbSet<Registration> Registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply Configuration Classes
            modelBuilder.ApplyConfiguration(new AttendeeConfiguration());
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationConfiguration());

            // Event Fluent API
            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Description)
                    .IsRequired();

                // Organizer Relationship
                entity.HasOne(e => e.Organizer)
                    .WithMany(o => o.Events)
                    .HasForeignKey(e => e.OrganizerId);

                // Self Referencing Relationship
                entity.HasOne(e => e.ParentEvent)
                    .WithMany(e => e.Sessions)
                    .HasForeignKey(e => e.ParentEventId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Shadow Properties
                entity.Property<DateTime>("CreatedAt");

                entity.Property<DateTime>("LastModifiedAt");
            });

            // Organizer ↔ Profile One-to-One
            modelBuilder.Entity<Organizer>()
                .HasOne(o => o.Profile)
                .WithOne(p => p.Organizer)
                .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);
        }
    }
    }
