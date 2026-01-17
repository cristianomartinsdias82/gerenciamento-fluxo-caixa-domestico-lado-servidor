using Application.Common.Validation;
using FluentValidation;

namespace Application.Features.Categories.ListCategories;

public sealed class ListCategoriesQueryValidator
	: AbstractValidator<ListCategoriesQuery>
{
	public ListCategoriesQueryValidator()
	{
		RuleFor(query => query.QueryParams)
			.SetValidator(new QueryParamsValidator());
	}
}
