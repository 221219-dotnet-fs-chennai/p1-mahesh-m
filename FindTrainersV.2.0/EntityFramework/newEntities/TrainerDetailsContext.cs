using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EntityFramework.newEntities;

public partial class TrainerDetailsContext : DbContext
{
    public TrainerDetailsContext()
    {
    }

    public TrainerDetailsContext(DbContextOptions<TrainerDetailsContext> options)
        : base(options)
    {
    }

   


    public virtual DbSet<CollegeUg> CollegeUgs { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<HighSchool> HighSchools { get; set; }

    public virtual DbSet<HighSec> HighSecs { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=OCTOTHORPE;Database=TrainerDetails;Trusted_Connection=True; Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CollegeUg>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK_UG");

            entity.ToTable("College_UG");

            entity.Property(e => e.TrainerId)
                .IsUnicode(false)
                .HasColumnName("trainerId");
            entity.Property(e => e.Branch).IsUnicode(false);
            entity.Property(e => e.CollegeName).IsUnicode(false);
            entity.Property(e => e.Degree).IsUnicode(false);
            entity.Property(e => e.YearPassed).IsUnicode(false);

            entity.HasOne(d => d.Trainer).WithOne(p => p.CollegeUg)
                .HasForeignKey<CollegeUg>(d => d.TrainerId)
                .HasConstraintName("FK_UG");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Companie__3214EC072C31B587");

            entity.Property(e => e.LastCompanyName).IsUnicode(false);
            entity.Property(e => e.TrainerId)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasColumnName("trainerId");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Companies)
                .HasForeignKey(d => d.TrainerId)
                .HasConstraintName("FK_Com");
        });

        modelBuilder.Entity<HighSchool>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK_HS ");

            entity.ToTable("HighSchool");

            entity.Property(e => e.TrainerId)
                .IsUnicode(false)
                .HasColumnName("trainerId");
            entity.Property(e => e.SchoolName).IsUnicode(false);
            entity.Property(e => e.YearPassed).IsUnicode(false);

            entity.HasOne(d => d.Trainer).WithOne(p => p.HighSchool)
                .HasForeignKey<HighSchool>(d => d.TrainerId)
                .HasConstraintName("FK_HS");
        });

        modelBuilder.Entity<HighSec>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK_HSC ");

            entity.ToTable("HighSec");

            entity.Property(e => e.TrainerId)
                .IsUnicode(false)
                .HasColumnName("trainerId");
            entity.Property(e => e.Course).IsUnicode(false);
            entity.Property(e => e.SchoolName).IsUnicode(false);
            entity.Property(e => e.YearPassed).IsUnicode(false);

            entity.HasOne(d => d.Trainer).WithOne(p => p.HighSec)
                .HasForeignKey<HighSec>(d => d.TrainerId)
                .HasConstraintName("FK_HSC");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.TrainerId);

            entity.Property(e => e.TrainerId).IsUnicode(false);
            entity.Property(e => e.Skill1)
                .IsUnicode(false)
                .HasColumnName("Skill_1");
            entity.Property(e => e.Skill2)
                .IsUnicode(false)
                .HasColumnName("Skill_2");
            entity.Property(e => e.Skill3)
                .IsUnicode(false)
                .HasColumnName("Skill_3");
            entity.Property(e => e.Skill4)
                .IsUnicode(false)
                .HasColumnName("Skill_4");

            entity.HasOne(d => d.Trainer).WithOne(p => p.Skill)
                .HasForeignKey<Skill>(d => d.TrainerId)
                .HasConstraintName("FK_Skills");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK_Users");

            entity.HasIndex(e => e.TrainerId, "UK_trainers").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Trainers__A9D10534B8A022DC").IsUnique();

            entity.HasIndex(e => e.PhoneNo, "UQ__Trainers__F3EE33E254D84B85").IsUnique();

            entity.Property(e => e.TrainerId).IsUnicode(false);
            entity.Property(e => e.City).IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).IsUnicode(false);
            entity.Property(e => e.LastName).IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
