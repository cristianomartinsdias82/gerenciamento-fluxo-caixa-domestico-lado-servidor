using HouseholdCashFlowManagementApi.Common.Searching;

namespace Application.Features.Transactions.ListTransactions;

public sealed record ListTransactionsQuery
{
	public required QueryParams QueryParams { get; init; }
}
