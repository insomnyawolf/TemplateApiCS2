using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Database.Models;

namespace webapi.Database;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectDealTypeEnum> ProjectDealTypeEnums { get; set; }

    public virtual DbSet<ProjectGroup> ProjectGroups { get; set; }

    public virtual DbSet<ProjectStatusEnum> ProjectStatusEnums { get; set; }

    public virtual DbSet<WindTurbine> WindTurbines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasOne(d => d.Company).WithMany(p => p.Projects).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.DealType).WithMany(p => p.Projects).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Group).WithMany(p => p.Projects).OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Status).WithMany(p => p.Projects).OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<WindTurbine>(entity =>
        {
            entity.HasOne(d => d.Project).WithMany(p => p.WindTurbines).OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
