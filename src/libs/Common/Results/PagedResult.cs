using Common.Extensions;
using HouseholdCashFlowManagementApi.Common.Searching;

namespace Common.Results;

public sealed record PagedResult<T>
{
	private PagedResult() { }

	public QueryParams QueryParams { get; private set; } = default!;
	public List<T> Items { get; private set; } = [];
	public int ItemCount { get; private set; }
	public int PageCount { get; private set; }
	public int? NextPage { get => QueryParams.PageNumber < PageCount ? QueryParams.PageNumber + 1 : null; }
	public int? PreviousPage { get => QueryParams.PageNumber <= 1 ? null : QueryParams.PageNumber - 1; }

	public static PagedResult<T> Create(IQueryable<T> source, QueryParams queryParams)
	{
		var itemCount = source.Count(LinqExtensions.CreateStringContainsExpression<T>(
													queryParams.FieldToSearchBy,
													queryParams.SearchTerm));

		return new()
		{
			QueryParams = queryParams,
			Items = source.Query(queryParams).ToList(),
			ItemCount = itemCount,
			PageCount = (int)Math.Ceiling(itemCount / (double)queryParams.PageSize)
		};
	}
}
