using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VeterinarClinicApi.Models;

public partial class GoncharovaContext : DbContext
{
    public GoncharovaContext()
    {
    }

    public GoncharovaContext(DbContextOptions<GoncharovaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Medicalhistory> Medicalhistories { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Servicedoctor> Servicedoctors { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("pk_animal");

            entity.ToTable("animals");

            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Breed)
                .HasMaxLength(100)
                .HasDefaultValueSql("'Отсутствует'::character varying")
                .HasColumnName("breed");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Owner).HasColumnName("owner");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.OwnerNavigation).WithMany(p => p.Animals)
                .HasForeignKey(d => d.Owner)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_owner_to_animal");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("pk_doctor");

            entity.ToTable("doctors");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.Hiredate).HasColumnName("hiredate");
            entity.Property(e => e.Honors).HasColumnName("honors");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Profession)
                .HasMaxLength(150)
                .HasColumnName("profession");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<Medicalhistory>(entity =>
        {
            entity.HasKey(e => e.KardId).HasName("pk_kard");

            entity.ToTable("medicalhistory");

            entity.Property(e => e.KardId).HasColumnName("kard_id");
            entity.Property(e => e.Animal).HasColumnName("animal");
            entity.Property(e => e.Doctor).HasColumnName("doctor");
            entity.Property(e => e.Service).HasColumnName("service");
            entity.Property(e => e.Visitingtime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("visitingtime");

            entity.HasOne(d => d.AnimalNavigation).WithMany(p => p.Medicalhistories)
                .HasForeignKey(d => d.Animal)
                .HasConstraintName("fk_animal_to_kard");

            entity.HasOne(d => d.DoctorNavigation).WithMany(p => p.Medicalhistories)
                .HasForeignKey(d => d.Doctor)
                .HasConstraintName("fk_doctor_to_kard");

            entity.HasOne(d => d.ServiceNavigation).WithMany(p => p.Medicalhistories)
                .HasForeignKey(d => d.Service)
                .HasConstraintName("fk_service_to_kard");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("pk_service");

            entity.ToTable("services");

            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Servicedoctor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("servicedoctor");

            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Doctor).WithMany()
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("fk_doctor_to_servicedoctor");

            entity.HasOne(d => d.Service).WithMany()
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("fk_service_to_servicedoctor");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("pk_user");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "un_user_email").IsUnique();

            entity.HasIndex(e => e.Phone, "un_user_phone").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .HasColumnName("surname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
