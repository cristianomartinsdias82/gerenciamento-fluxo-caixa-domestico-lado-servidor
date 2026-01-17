using Application.Common.Validation;
using FluentValidation;

namespace Application.Features.People.ListPeople;

public sealed class ListPeopleQueryValidator
	: AbstractValidator<ListPeopleQuery>
{
	public ListPeopleQueryValidator()
	{
		RuleFor(query => query.QueryParams)
			.SetValidator(new QueryParamsValidator());
	}
}
