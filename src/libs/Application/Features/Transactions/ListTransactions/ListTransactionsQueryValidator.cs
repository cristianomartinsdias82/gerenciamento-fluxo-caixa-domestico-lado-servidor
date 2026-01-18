using Application.Common.Validation;
using FluentValidation;

namespace Application.Features.Transactions.ListTransactions;

public sealed class ListTransactionsQueryValidator
	: AbstractValidator<ListTransactionsQuery>
{
	public ListTransactionsQueryValidator()
	{
		RuleFor(query => query.QueryParams)
			.SetValidator(new QueryParamsValidator());
	}
}
