using HouseholdCashFlowManagementApi.Common.Searching;

namespace Common.Searching;

public sealed record PagedResult<T>
{
	public required QueryParams QueryParams { get; init; }
	public required List<T> Items { get; init; }
	public required int ItemCount { get; init; }
	public required int PageCount { get; init; }
	public int? NextPage { get => QueryParams.PageNumber < PageCount ? QueryParams.PageNumber + 1 : null; }
	public int? PreviousPage { get => QueryParams.PageNumber <= 1 ? null : QueryParams.PageNumber - 1; }
}
