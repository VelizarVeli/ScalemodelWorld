﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Scalemodels.Models;
using Scalemodels.Models.JunctionClasses;
using Scalemodels.Models.Modelshows;
using Scalemodels.Models.Scalemodels;
using ScalemodelWorld.Web.Areas.Identity.Data;

namespace ScalemodelWorld.Web.Models
{
    public class ScalemodelWorldContext : IdentityDbContext<ScalemodelWorldUser>
    {
        public ScalemodelWorldContext(DbContextOptions<ScalemodelWorldContext> options)
            : base(options)
        {
        }

        public DbSet<Aftermarket> Aftermarkets { get; set; }
        public DbSet<AvailableScalemodel> AvailableScalemodels { get; set; }
        public DbSet<CompletedScalemodel> CompletedScalemodels { get; set; }
        public DbSet<Manifacturer> Manifacturers { get; set; }
        public DbSet<StartedScalemodel> StartedScalemodels { get; set; }
        public DbSet<WishScalemodel> WishScalemodels { get; set; }
        public DbSet<CompletedAftermarket> CompletedAftermarkets { get; set; }
        public DbSet<StartedAftermarket> StartedAftermarkets { get; set; }
        public DbSet<ModelShow> ModelShows { get; set; }
        public DbSet<CompletedScalemodelShowParticipation> CompletedScalemodelShowParticipations { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<ConsumableCategory> ConsumableCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ScalemodelWorldUser>().ToTable("User");
            builder.Entity<ScalemodelWorldUser>().Property(u => u.PasswordHash).HasMaxLength(500);
            // builder.Entity<User>().Property(u => u.Stamp).HasMaxLength(500);
            builder.Entity<ScalemodelWorldUser>().Property(u => u.PhoneNumber).HasMaxLength(50);

            //builder.Entity<Role>().ToTable("Role");
            //builder.Entity<UserRole>().ToTable("UserRole");
            //builder.Entity<UserLogin>().ToTable("UserLogin");
            //builder.Entity<UserClaim>().ToTable("UserClaim");
            //builder.Entity<UserClaim>().Property(u => u.ClaimType).HasMaxLength(150);
            //builder.Entity<UserClaim>().Property(u => u.ClaimValue).HasMaxLength(500);

            builder.Entity<AvailableAftermarket>()
                .HasKey(sa => new { sa.AvailableAftermarketId, sa.AvailableScalemodelId });

            builder.Entity<AvailableAftermarket>()
                .HasOne(a => a.Aftermarket)
                .WithMany(s => s.AvailableScalemodels)
                .HasForeignKey(fk => fk.AvailableAftermarketId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AvailableAftermarket>()
                .HasOne(a => a.AvailableScalemodel)
                .WithMany(s => s.AvailableAndPurchasedAftermarkets)
                .HasForeignKey(fk => fk.AvailableScalemodelId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<CompletedAftermarket>()
                .HasKey(sa => new { sa.CompletedAftermarketId, sa.CompletedScalemodelId });

            builder.Entity<CompletedAftermarket>()
                .HasOne(a => a.Aftermarket)
                .WithMany(s => s.CompletedScalemodels)
                .HasForeignKey(fk => fk.CompletedAftermarketId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CompletedAftermarket>()
                .HasOne(a => a.CompletedScalemodel)
                .WithMany(s => s.Aftermarkets)
                .HasForeignKey(fk => fk.CompletedScalemodelId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<StartedAftermarket>()
                .HasKey(sa => new { sa.StartedAftermarketId, sa.StartedScalemodelId });

            builder.Entity<StartedAftermarket>()
                .HasOne(a => a.Aftermarket)
                .WithMany(s => s.StartedScalemodels)
                .HasForeignKey(fk => fk.StartedAftermarketId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<StartedAftermarket>()
                .HasOne(a => a.StartedScalemodel)
                .WithMany(b => b.StartAftermarkets)
                .HasForeignKey(fk => fk.StartedScalemodelId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<CompletedScalemodelShowParticipation>()
                .HasKey(sa => new { sa.CompletedScalemodelId, sa.ModelshowId });

            builder.Entity<CompletedScalemodelShowParticipation>()
                .HasOne(a => a.CompletedScalemodel)
                .WithMany(s => s.ModelShowsParticipatedIn)
                .HasForeignKey(fk => fk.CompletedScalemodelId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CompletedScalemodelShowParticipation>()
                .HasOne(a => a.Modelshow)
                .WithMany(b => b.Participants)
                .HasForeignKey(fk => fk.ModelshowId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}