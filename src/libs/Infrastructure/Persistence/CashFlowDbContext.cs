using Application.Common.Data;
using Common.Results;
using Domain.Entities;
using HouseholdCashFlowManagementApi.Common.Searching;
using Infrastructure.Persistence.ValueConverter;
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

	public async Task<PagedResult<T>> QueryAsync<T>(
		QueryParams queryParams,
		CancellationToken cancellationToken) where T : class
		=> PagedResult<T>.Create(
			Set<T>(),
			queryParams);

	public async Task<PagedResult<TDestination>> MappedQueryAsync<TSource, TDestination>(
		QueryParams queryParams,
		Func<TSource, TDestination> map,
		CancellationToken cancellationToken) where TSource : class
		=> PagedResult<TDestination>.Create(
			Set<TSource>().Select(map).AsQueryable(),
			queryParams);

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		
		modelBuilder.Entity<Person>().ToCollection("People");

		modelBuilder.Entity<Category>().ToCollection("Categories");
		modelBuilder.Entity<Category>()
			.Property(atc => atc.Purpose)
			   .IsRequired()
			   .HasConversion(new EnumToStringDescriptionConverter<CategoryPurpose>());
	}
}