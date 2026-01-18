using Application.Common.Data;
using Common.Searching;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.People.ListPeople;

public sealed class ListPeopleQueryHandler(ICashFlowDbContext dbContext)
{
	public async ValueTask<PagedResult<PeopleListItemDto>> Handle(ListPeopleQuery query, CancellationToken cancellationToken)
	{
		//This could for sure be optimized with caching (HybridCache?) but for the sake of this example, we will keep it simple.
		var categories = await dbContext
								.Categories
								.ToListAsync();

		return await dbContext.MappedQueryAsync<Person, PeopleListItemDto>(
			query.QueryParams with { FieldToSearchBy = nameof(Person.FullName) },
			person => new PeopleListItemDto
			{
				Id = person.Id,
				FullName = person.FullName,
				Age = person.Age,
				Transactions = query.IncludeTransactions
										? person.Transactions
													.Select(TransactionDto.Selector)
													.ToList()
										: []
			},
			cancellationToken);
	}
}