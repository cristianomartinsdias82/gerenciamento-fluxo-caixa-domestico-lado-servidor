namespace HouseholdCashFlowManagementApi.Common.Searching;

public sealed record QueryParams
{
	public const string DefaultSortBy = "id";
	public const string DefaultSortDirection = "desc";
	public const int DefaultPageNumber = 1;
	public const int DefaultPageSize = 10;

	public int PageNumber { get; init; } = DefaultPageNumber;
	public int PageSize { get; init; } = DefaultPageSize;
	public string? SortBy { get; init; } = DefaultSortBy;
	public string? SortDirection { get; init; } = DefaultSortDirection;
	public string? SearchTerm { get; init; }
	public string? FieldToSearchBy { get; set; }
}
