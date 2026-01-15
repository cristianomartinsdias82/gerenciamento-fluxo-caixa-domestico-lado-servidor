using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Data;

public interface ICashFlowDbContext
{
	DbSet<Person> People { get; }
	DbSet<Category> Categories { get; }
	DbSet<T> Set<T>() where T : class;
}
