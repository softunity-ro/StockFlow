﻿using StockFlow.Domain.Common;
using StockFlow.Domain.Locations;
using StockFlow.Domain.Stocks;

namespace StockFlow.Domain.Materials;

/// <summary>
/// Represents a raw material
/// </summary>
public class Material : EntityBase
{
    public string PartNumber { get; set; } = null!;
    public SizeType SizeType { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Position> Positions { get; set; } = Enumerable.Empty<Position>();
    public IEnumerable<Stock> Stocks { get; set; } = Enumerable.Empty<Stock>();
}