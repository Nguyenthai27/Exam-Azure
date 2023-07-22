using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DMAWS_T2203E_ThangDo.Entities;

public partial class ExamDmawsContext : DbContext
{
    public ExamDmawsContext()
    {
    }

    public ExamDmawsContext(DbContextOptions<ExamDmawsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectEmployee> ProjectEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-T5VUP41;Initial Catalog=ExamDMAWS;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F11D3AE7725");

            entity.Property(e => e.EmployeeDepartment)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeDob)
                .HasColumnType("datetime")
                .HasColumnName("EmployeeDOB");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF0532EBA16");

            entity.Property(e => e.ProjectEndDate).HasColumnType("datetime");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProjectStartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProjectEmployee>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProjectEmployee");

            entity.Property(e => e.Tasks)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany()
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__ProjectEm__Emplo__49C3F6B7");

            entity.HasOne(d => d.Project).WithMany()
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__ProjectEm__Proje__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
