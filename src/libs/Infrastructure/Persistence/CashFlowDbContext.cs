using Application.Common.Data;
using Common.Extensions;
using Common.Searching;
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
		=> await MappedQueryAsync<T, T>(
			queryParams,
			x => x,
			cancellationToken);

	public async Task<PagedResult<TDestination>> MappedQueryAsync<TSource, TDestination>(
		QueryParams queryParams,
		Func<TSource, TDestination> map,
		CancellationToken cancellationToken) where TSource : class
	{
		var queryable = Set<TSource>().AsQueryable();

		var totalCount = await queryable.CountAsync(
											LinqExtensions.CreateStringContainsExpression<TSource>(queryParams.FieldToSearchBy, queryParams.SearchTerm),
											cancellationToken);

		var items = await queryable
							.Query(queryParams)
							.ToListAsync(cancellationToken);

		return new PagedResult<TDestination>
		{
			QueryParams = queryParams,
			Items = items.Select(map).ToList(),
			ItemCount = totalCount,
			PageCount = (int)Math.Ceiling((double)totalCount / queryParams.PageSize)
		};
	}

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