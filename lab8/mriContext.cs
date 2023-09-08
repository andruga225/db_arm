using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace lab8
{
    public partial class mriContext : DbContext
    {
        public mriContext()
        {
        }

        public mriContext(DbContextOptions<mriContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<EmpPo> EmpPos { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<MriCan> MriCans { get; set; }
        public virtual DbSet<MriMachine> MriMachines { get; set; }
        public virtual DbSet<Patinet> Patinets { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=mri;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum(null, "fin", new[] { "Частное", "Государственное" })
                .HasPostgresEnum(null, "live", new[] { "Жилое", "Нежилое" })
                .HasPostgresEnum(null, "sex", new[] { "Мужской", "Женский" })
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.IdBuilding)
                    .HasName("buildings_pk");

                entity.ToTable("buildings");

                entity.HasIndex(e => e.IdBuilding, "buildings_id_building_uindex")
                    .IsUnique();

                entity.Property(e => e.IdBuilding)
                    .HasColumnName("id_building")
                    .HasDefaultValueSql("nextval('\"buildings_ID_building_seq\"'::regclass)");

                entity.Property(e => e.BuildingAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("building_address");

                entity.Property(e => e.BuildingFloors).HasColumnName("building_floors");

                entity.Property(e => e.BuildingType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("building_type");
            });

            modelBuilder.Entity<Clinic>(entity =>
            {
                entity.HasKey(e => e.IdClinic)
                    .HasName("clinics_pk");

                entity.ToTable("clinics");

                entity.HasIndex(e => e.IdClinic, "clinics_id_clinic_uindex")
                    .IsUnique();

                entity.Property(e => e.IdClinic)
                    .HasColumnName("id_clinic")
                    .HasDefaultValueSql("nextval('\"clinics_ID_clinic_seq\"'::regclass)");

                entity.Property(e => e.ClinicEmployers).HasColumnName("clinic_employers");

                entity.Property(e => e.ClinicFinance)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("clinic_finance");

                entity.Property(e => e.ClinicName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("clinic_name");

                entity.Property(e => e.IdBuilding).HasColumnName("id_building");

                entity.HasOne(d => d.IdBuildingNavigation)
                    .WithMany(p => p.Clinics)
                    .HasForeignKey(d => d.IdBuilding)
                    .HasConstraintName("clinics_buildings_id_building_fk");
            });

            modelBuilder.Entity<EmpPo>(entity =>
            {
                entity.HasKey(e => new { e.IdClinic, e.IdEmployer, e.Position })
                    .HasName("emp_pos_pk");

                entity.ToTable("emp_pos");

                entity.Property(e => e.IdClinic).HasColumnName("id_clinic");

                entity.Property(e => e.IdEmployer).HasColumnName("id_employer");

                entity.Property(e => e.Position)
                    .HasMaxLength(100)
                    .HasColumnName("position");

                entity.HasOne(d => d.IdClinicNavigation)
                    .WithMany(p => p.EmpPos)
                    .HasForeignKey(d => d.IdClinic)
                    .HasConstraintName("emp_pos_clinics_id_clinic_fk");

                entity.HasOne(d => d.IdEmployerNavigation)
                    .WithMany(p => p.EmpPos)
                    .HasForeignKey(d => d.IdEmployer)
                    .HasConstraintName("emp_pos_employers_id_employer_fk");

                entity.HasOne(d => d.PositionNavigation)
                    .WithMany(p => p.EmpPos)
                    .HasForeignKey(d => d.Position)
                    .HasConstraintName("emp_pos_position_position_fk");
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.HasKey(e => e.IdEmployer)
                    .HasName("employers_pk");

                entity.ToTable("employers");

                entity.HasIndex(e => e.IdEmployer, "employers_id_employer_uindex")
                    .IsUnique();

                entity.Property(e => e.IdEmployer)
                    .HasColumnName("id_employer")
                    .HasDefaultValueSql("nextval('\"employers_ID_employer_seq\"'::regclass)");

                entity.Property(e => e.EmployerBirthday)
                    .HasColumnType("date")
                    .HasColumnName("employer_birthday");

                entity.Property(e => e.EmployerExperience).HasColumnName("employer_experience");

                entity.Property(e => e.EmployerMiddleName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("employer_middle_name");

                entity.Property(e => e.EmployerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("employer_name");

                entity.Property(e => e.EmployerSex)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("employer_sex");

                entity.Property(e => e.EmployerSurname)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("employer_surname");
            });

            modelBuilder.Entity<MriCan>(entity =>
            {
                entity.HasKey(e => new { e.IdService, e.IdMachine, e.IdEmployer, e.IdPatient, e.ScanDate })
                    .HasName("mri scans_pk");

                entity.ToTable("mri _cans");

                entity.Property(e => e.IdService).HasColumnName("ID_service");

                entity.Property(e => e.IdMachine).HasColumnName("ID_machine");

                entity.Property(e => e.IdEmployer).HasColumnName("ID_employer");

                entity.Property(e => e.IdPatient).HasColumnName("ID_patient");

                entity.Property(e => e.ScanDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(now())::date");

                entity.Property(e => e.ResultDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(now())::date");

                entity.HasOne(d => d.IdEmployerNavigation)
                    .WithMany(p => p.MriCans)
                    .HasForeignKey(d => d.IdEmployer)
                    .HasConstraintName("mri _cans_employers_id_employer_fk");

                entity.HasOne(d => d.IdMachineNavigation)
                    .WithMany(p => p.MriCans)
                    .HasForeignKey(d => d.IdMachine)
                    .HasConstraintName("mri _cans_mri_machines_id_machine_fk");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.MriCans)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("mri _cans_patinets_id_patient_fk");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.MriCans)
                    .HasForeignKey(d => d.IdService)
                    .HasConstraintName("mri _cans_service_id_service_fk");
            });

            modelBuilder.Entity<MriMachine>(entity =>
            {
                entity.HasKey(e => e.IdMachine)
                    .HasName("mri_machines_pk");

                entity.ToTable("mri_machines");

                entity.HasIndex(e => e.IdMachine, "mri_machines_id_machine_uindex")
                    .IsUnique();

                entity.Property(e => e.IdMachine).HasColumnName("ID_machine");

                entity.Property(e => e.IdClinic).HasColumnName("ID_clinic");

                entity.Property(e => e.MachineType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("machineType");

                entity.Property(e => e.SerialNumber).HasColumnName("serialNumber");

                entity.HasOne(d => d.IdClinicNavigation)
                    .WithMany(p => p.MriMachines)
                    .HasForeignKey(d => d.IdClinic)
                    .HasConstraintName("mri_machines_clinics_id_clinic_fk");
            });

            modelBuilder.Entity<Patinet>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("patinets_pk");

                entity.ToTable("patinets");

                entity.HasIndex(e => e.IdPatient, "patinets_id_patient_uindex")
                    .IsUnique();

                entity.Property(e => e.IdPatient)
                    .HasColumnName("ID_patient")
                    .HasDefaultValueSql("nextval('\"Patinets_ID_patient_seq\"'::regclass)");

                entity.Property(e => e.PatientBirthday).HasColumnType("date");

                entity.Property(e => e.PatientMiddleName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PatientName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PatientSurname)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.Position1)
                    .HasName("table_name_pk");

                entity.ToTable("position");

                entity.Property(e => e.Position1)
                    .HasMaxLength(100)
                    .HasColumnName("position");

                entity.Property(e => e.Permission).HasColumnName("permission");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdService)
                    .HasName("service_pk");

                entity.ToTable("service");

                entity.HasIndex(e => e.IdService, "service_id_service_uindex")
                    .IsUnique();

                entity.Property(e => e.IdService)
                    .HasColumnName("id_service")
                    .HasDefaultValueSql("nextval('\"service_ID_service_seq\"'::regclass)");

                entity.Property(e => e.Organ)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("organ");

                entity.Property(e => e.OrganGroup)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("organ_group");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Login, "users_login_uindex")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
