using FluentValidation;
using HouseholdCashFlowManagementApi.Common.Searching;

namespace Application.Common.Validation;

public sealed class QueryParamsValidator
	: AbstractValidator<QueryParams>
{
	public QueryParamsValidator()
	{
		RuleFor(x => x.PageNumber)
			.GreaterThan(0)
			.WithMessage("Page number must be greater than 0.");

		RuleFor(x => x.PageSize)
			.GreaterThan(0)
			.WithMessage("Page number must be greater than 0.")
			.LessThanOrEqualTo(50)
			.WithMessage("Page size must be no more than 50.");

		When(queryParams => !string.IsNullOrEmpty(queryParams.SortDirection), () =>
		{
			RuleFor(x => x.SortDirection)
				.Must(direction =>
					direction!.Equals("asc", StringComparison.OrdinalIgnoreCase) ||
					direction!.Equals("desc", StringComparison.OrdinalIgnoreCase))
				.WithMessage("Sort direction must be either 'asc' or 'desc'.");
		});
	}
}
