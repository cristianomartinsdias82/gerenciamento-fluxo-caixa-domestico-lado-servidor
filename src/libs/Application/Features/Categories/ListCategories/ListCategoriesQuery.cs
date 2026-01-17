using HouseholdCashFlowManagementApi.Common.Searching;

namespace Application.Features.Categories.ListCategories;

public sealed record ListCategoriesQuery
{
	public required QueryParams QueryParams { get; init; }
}
