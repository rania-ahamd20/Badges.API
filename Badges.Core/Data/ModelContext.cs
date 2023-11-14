using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Badges.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<AssignmentsTrainee> AssignmentsTrainees { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Badge> Badges { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseTrainee> CourseTrainees { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("USER ID=c##React;PASSWORD=123;DATA SOURCE=localhost:1521/xe;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##REACT")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => e.Assignmentsid)
                    .HasName("SYS_C008521");

                entity.ToTable("ASSIGNMENTS");

                entity.Property(e => e.Assignmentsid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ASSIGNMENTSID");

                entity.Property(e => e.Datecreate)
                    .HasColumnType("DATE")
                    .HasColumnName("DATECREATE");

                entity.Property(e => e.Deadline)
                    .HasColumnType("DATE")
                    .HasColumnName("DEADLINE");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.FkCourseid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_COURSEID");

                entity.Property(e => e.Mark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MARK");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.FkCourse)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.FkCourseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008522");
            });

            modelBuilder.Entity<AssignmentsTrainee>(entity =>
            {
                entity.HasKey(e => e.Atid)
                    .HasName("SYS_C008537");

                entity.ToTable("ASSIGNMENTS_TRAINEE");

                entity.Property(e => e.Atid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATID");

                entity.Property(e => e.FkAssignmentsid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_ASSIGNMENTSID");

                entity.Property(e => e.FkUserid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_USERID");

                entity.Property(e => e.Mark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MARK");

                entity.Property(e => e.Submitdate)
                    .HasColumnType("DATE")
                    .HasColumnName("SUBMITDATE");

                entity.HasOne(d => d.FkAssignments)
                    .WithMany(p => p.AssignmentsTrainees)
                    .HasForeignKey(d => d.FkAssignmentsid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008539");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.AssignmentsTrainees)
                    .HasForeignKey(d => d.FkUserid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008538");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("ATTENDANCE");

                entity.Property(e => e.Attendanceid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ATTENDANCEID");

                entity.Property(e => e.Attendantedate)
                    .HasColumnType("DATE")
                    .HasColumnName("ATTENDANTEDATE");

                entity.Property(e => e.FkCourseid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_COURSEID");

                entity.Property(e => e.FkUserid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_USERID");

                entity.Property(e => e.Numattendance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("NUMATTENDANCE");

                entity.HasOne(d => d.FkCourse)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.FkCourseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008535");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.FkUserid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008534");
            });

            modelBuilder.Entity<Badge>(entity =>
            {
                entity.HasKey(e => e.Badgesid)
                    .HasName("SYS_C008524");

                entity.ToTable("BADGES");

                entity.Property(e => e.Badgesid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BADGESID");

                entity.Property(e => e.FkAssignments)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_ASSIGNMENTS");

                entity.Property(e => e.FkCourseid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_COURSEID");

                entity.Property(e => e.FkUserid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_USERID");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Text)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("TEXT");

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.HasOne(d => d.FkAssignmentsNavigation)
                    .WithMany(p => p.Badges)
                    .HasForeignKey(d => d.FkAssignments)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008527");

                entity.HasOne(d => d.FkCourse)
                    .WithMany(p => p.Badges)
                    .HasForeignKey(d => d.FkCourseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008525");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Badges)
                    .HasForeignKey(d => d.FkUserid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008526");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("COURSE");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Coursenum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COURSENUM");

                entity.Property(e => e.Datefrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFROM");

                entity.Property(e => e.Dateto)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETO");

                entity.Property(e => e.Duration)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DURATION");

                entity.Property(e => e.FkUserid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_USERID");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Sectionnum)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SECTIONNUM");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.FkUserid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008519");
            });

            modelBuilder.Entity<CourseTrainee>(entity =>
            {
                entity.HasKey(e => e.Ctid)
                    .HasName("SYS_C008529");

                entity.ToTable("COURSE_TRAINEE");

                entity.Property(e => e.Ctid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CTID");

                entity.Property(e => e.FkCourseid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_COURSEID");

                entity.Property(e => e.FkUserid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_USERID");

                entity.Property(e => e.Mark)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MARK");

                entity.HasOne(d => d.FkCourse)
                    .WithMany(p => p.CourseTrainees)
                    .HasForeignKey(d => d.FkCourseid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008531");

                entity.HasOne(d => d.FkUser)
                    .WithMany(p => p.CourseTrainees)
                    .HasForeignKey(d => d.FkUserid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008530");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.FkRoleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FK_ROLEID");

                entity.Property(e => e.Image)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.FkRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.FkRoleid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("SYS_C008516");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
