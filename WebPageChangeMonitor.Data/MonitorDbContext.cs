﻿using Microsoft.EntityFrameworkCore;
using WebPageChangeMonitor.Data.Configurations;
using WebPageChangeMonitor.Data.Entities;

namespace WebPageChangeMonitor.Data;

public class MonitorDbContext : DbContext
{
    public DbSet<ResourceEntity> Resources { get; set; }
    public DbSet<TargetEntity> Targets { get; set; }

    public MonitorDbContext(DbContextOptions<MonitorDbContext> options)
        : base(options) 
    { }

    // todo enable lazy loading
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("monitor");
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ResourceEntityConfiguration());

        // todo add TargetEntity configs
    }
}