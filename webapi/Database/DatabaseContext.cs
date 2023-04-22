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

    public virtual DbSet<TaskStateEnum> TaskStateEnums { get; set; }

    public virtual DbSet<TasksItem> TasksItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
