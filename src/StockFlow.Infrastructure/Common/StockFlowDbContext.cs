﻿using Microsoft.EntityFrameworkCore;
using StockFlow.Domain.ActionLogs;
using StockFlow.Domain.Locations;
using StockFlow.Domain.Materials;
using StockFlow.Domain.Stocks;
using System.Reflection;
using StockFlow.Application.Common;

namespace StockFlow.Infrastructure.Common;

public class StockFlowDbContext : DbContext, IUnitOfWork
{
    public DbSet<Material> Materials => Set<Material>();
    public DbSet<Rack> Racks => Set<Rack>();
    public DbSet<Position> Positions => Set<Position>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<ActionLog> ActionLogs => Set<ActionLog>();

    public StockFlowDbContext(DbContextOptions<StockFlowDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public async Task CommitChangesAsync(CancellationToken cancellationToken = default)
    {
        await SaveChangesAsync(cancellationToken);
    }
}