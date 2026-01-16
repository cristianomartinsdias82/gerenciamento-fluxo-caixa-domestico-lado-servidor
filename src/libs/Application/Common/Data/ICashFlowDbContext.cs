using Domain.Entities;
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
}
