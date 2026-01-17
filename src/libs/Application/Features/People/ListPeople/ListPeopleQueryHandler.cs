using Application.Common.Data;
using Common.Searching;
using Domain.Entities;

namespace Application.Features.People.ListPeople;

public sealed class ListPeopleQueryHandler(ICashFlowDbContext dbContext)
{
	public async ValueTask<PagedResult<PeopleListItemDto>> Handle(ListPeopleQuery query, CancellationToken cancellationToken)
		=> await dbContext.MappedQueryAsync<Person, PeopleListItemDto>(
			query.QueryParams with { FieldToSearchBy = nameof(Person.FullName) },
			person => new PeopleListItemDto
			{
				Id = person.Id,
				FullName = person.FullName,
				Age = person.Age
			},
			cancellationToken);
}