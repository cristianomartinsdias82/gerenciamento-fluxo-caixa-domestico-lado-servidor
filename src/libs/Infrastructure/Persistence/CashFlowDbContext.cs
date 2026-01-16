using Application.Common.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Infrastructure.Persistence;

internal sealed class CashFlowDbContext
	: DbContext, ICashFlowDbContext
{
	public CashFlowDbContext(DbContextOptions options)
		: base(options) { }

	public DbSet<Person> People { get => Set<Person>(); }
	public DbSet<Category> Categories { get => Set<Category>(); }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		
		modelBuilder.Entity<Person>().ToCollection("People");
		modelBuilder.Entity<Category>().ToCollection("Categories");
	}
}
