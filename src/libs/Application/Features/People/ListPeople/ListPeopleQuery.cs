using HouseholdCashFlowManagementApi.Common.Searching;

namespace Application.Features.People.ListPeople;

public sealed record ListPeopleQuery
{
	public required QueryParams QueryParams { get; init; }
}
