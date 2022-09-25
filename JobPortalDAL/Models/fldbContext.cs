using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace JobPortalDAL.Models
{
    public partial class fldbContext : DbContext
    {
        public fldbContext()
        {
        }

        public fldbContext(DbContextOptions<fldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DomocileType> DomocileTypes { get; set; } = null!;
        public virtual DbSet<EducationalHistory> EducationalHistories { get; set; } = null!;
        public virtual DbSet<EmploymentHistory> EmploymentHistories { get; set; } = null!;
        public virtual DbSet<PersonalInformation> PersonalInformations { get; set; } = null!;
        public virtual DbSet<ReligionType> ReligionTypes { get; set; } = null!;

        private readonly string connectionString = "Data Source=SQL5107.site4now.net;Initial Catalog=db_a8bd38_jobportal;User Id=db_a8bd38_jobportal_admin;Password=jobportaldb1";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString); // Notice this change 
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(connectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DomocileType>(entity =>
            {
                entity.ToTable("domocile_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<EducationalHistory>(entity =>
            {
                entity.ToTable("educational_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DegressTitle)
                    .HasMaxLength(100)
                    .HasColumnName("degress_title");

                entity.Property(e => e.Grade)
                    .HasMaxLength(50)
                    .HasColumnName("grade");

                entity.Property(e => e.MajorSubject)
                    .HasMaxLength(255)
                    .HasColumnName("major_subject");

                entity.Property(e => e.PersonalInformationId).HasColumnName("personal_information_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.Property(e => e.YearPassing)
                    .HasMaxLength(50)
                    .HasColumnName("year_passing");

                entity.HasOne(d => d.PersonalInformation)
                    .WithMany(p => p.EducationalHistories)
                    .HasForeignKey(d => d.PersonalInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_educational_history_personal_information");
            });

            modelBuilder.Entity<EmploymentHistory>(entity =>
            {
                entity.ToTable("employment_history");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .HasColumnName("designation");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.IsCurrentJob).HasColumnName("is_current_job");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("date")
                    .HasColumnName("joining_date");

                entity.Property(e => e.LastSalary)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("last_salary");

                entity.Property(e => e.Organization)
                    .HasMaxLength(100)
                    .HasColumnName("organization");

                entity.Property(e => e.PersonalInformationId).HasColumnName("personal_information_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.PersonalInformation)
                    .WithMany(p => p.EmploymentHistories)
                    .HasForeignKey(d => d.PersonalInformationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_employment_history_personal_information");
            });

            modelBuilder.Entity<PersonalInformation>(entity =>
            {
                entity.ToTable("personal_information");

                entity.Property(e => e.PersonalInformationId).HasColumnName("personal_information_id");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(50)
                    .HasColumnName("contact_number");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CvPath).HasColumnName("cv_path");

                entity.Property(e => e.DomocileId).HasColumnName("domocile_id");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(100)
                    .HasColumnName("father_name");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .HasColumnName("full_name");

                entity.Property(e => e.MobileNumber)
                    .HasMaxLength(100)
                    .HasColumnName("mobile_number");

                entity.Property(e => e.Nic)
                    .HasMaxLength(200)
                    .HasColumnName("nic");

                entity.Property(e => e.PermenantAddress)
                    .HasMaxLength(255)
                    .HasColumnName("permenant_address");

                entity.Property(e => e.ReligionId).HasColumnName("religion_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");

                entity.HasOne(d => d.Domocile)
                    .WithMany(p => p.PersonalInformations)
                    .HasForeignKey(d => d.DomocileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_personal_information_domocile_type");

                entity.HasOne(d => d.Religion)
                    .WithMany(p => p.PersonalInformations)
                    .HasForeignKey(d => d.ReligionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_personal_information_religion_type");
            });

            modelBuilder.Entity<ReligionType>(entity =>
            {
                entity.ToTable("religion_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
