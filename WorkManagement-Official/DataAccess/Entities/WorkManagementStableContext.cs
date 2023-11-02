using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Entities
{
    public partial class WorkManagementStableContext : DbContext
    {
        public WorkManagementStableContext()
        {
        }

        public WorkManagementStableContext(DbContextOptions<WorkManagementStableContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<AppliedAndCared> AppliedAndCareds { get; set; } = null!;
        public virtual DbSet<AppliedUser> AppliedUsers { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Cvfile> Cvfiles { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;

        public virtual DbSet<JobField> JobFields { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()
                    .GetConnectionString("DefaultConnection") ?? ""
                    );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountKey)
                    .HasName("PK__Accounts__B914BFF1C1E25EA1");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompanyKeyNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CompanyKey)
                    .HasConstraintName("FK__Accounts__Compan__398D8EEE");
            });

            modelBuilder.Entity<AppliedAndCared>(entity =>
            {
                entity.HasKey(e => e.Aacjkey)
                    .HasName("PK__AppliedA__0B05388DE65AF118");

                entity.ToTable("AppliedAndCared");

                entity.Property(e => e.Aacjkey).HasColumnName("AACJKey");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.AppliedAndCareds)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppliedAn__Accou__4222D4EF");

                entity.HasOne(d => d.PostKeyNavigation)
                    .WithMany(p => p.AppliedAndCareds)
                    .HasForeignKey(d => d.PostKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppliedAn__PostK__4316F928");
            });

            modelBuilder.Entity<AppliedUser>(entity =>
            {
                entity.HasKey(e => e.Aufjkey)
                    .HasName("PK__AppliedU__781D982CDCBCF21E");

                entity.Property(e => e.Aufjkey).HasColumnName("AUFJKey");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.AppliedUsers)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppliedUs__Accou__45F365D3");

                entity.HasOne(d => d.CvFileKeyNavigation)
                    .WithMany(p => p.AppliedUsers)
                    .HasForeignKey(d => d.CvFileKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppliedUs__CvFil__47DBAE45");

                entity.HasOne(d => d.PostKeyNavigation)
                    .WithMany(p => p.AppliedUsers)
                    .HasForeignKey(d => d.PostKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppliedUs__PostK__46E78A0C");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.CompanyKey)
                    .HasName("PK__Companie__5A25F59B5B32AB1D");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ImageUrl).HasColumnType("text");

                entity.Property(e => e.Location)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.LogoUrl).HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.WorkField)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cvfile>(entity =>
            {
                entity.HasKey(e => e.CvfileKey)
                    .HasName("PK__CVFiles__64CFBAF4169F1C38");

                entity.ToTable("CVFiles");

                entity.Property(e => e.CvfileKey).HasColumnName("CVFileKey");

                entity.Property(e => e.CvfileSource)
                    .HasColumnType("text")
                    .HasColumnName("CVFileSource");

                entity.Property(e => e.Cvname)
                    .HasMaxLength(255)
                    .HasColumnName("CVName");

                entity.HasOne(d => d.AccountKeyNavigation)
                    .WithMany(p => p.Cvfiles)
                    .HasForeignKey(d => d.AccountKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CVFiles__Account__3C69FB99");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostKey)
                    .HasName("PK__Posts__55433F94D465D4F4");

                entity.Property(e => e.Benefits).HasColumnType("text");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ExperienceType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.JobField)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Level)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RequiredCandicate).HasColumnType("text");

                entity.Property(e => e.SalaryType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ToTime).HasColumnType("datetime");

                entity.Property(e => e.WorkType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CompanyKeyNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CompanyKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Posts__CompanyKe__3F466844");
            });
        }
    }
}
