using Common.Searching;
using Domain.Entities;
using HouseholdCashFlowManagementApi.Common.Searching;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Common.Data;

public interface ICashFlowDbContext
{
	DbSet<Person> People { get; }
	DbSet<Category> Categories { get; }
	DbSet<T> Set<T>() where T : class;
	DatabaseFacade Database { get; }
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	Task<PagedResult<T>> QueryAsync<T>(
		QueryParams queryParams,
		CancellationToken cancellationToken) where T : class;
	Task<PagedResult<TDestination>> MappedQueryAsync<TSource, TDestination>(
		QueryParams queryParams,
		Func<TSource, TDestination> map,
		CancellationToken cancellationToken) where TSource : class;
}
