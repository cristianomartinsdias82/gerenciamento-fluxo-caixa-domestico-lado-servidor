using HouseholdCashFlowManagementApi.Common.Searching;
using System.Linq.Expressions;

namespace Common.Extensions;

public static class LinqExtensions
{
	extension<T>(IQueryable<T> queryable) //where T : class
	{
		public IQueryable<T> Query(QueryParams queryParams)
			=> queryable
			.Filter(queryParams.SearchTerm, queryParams.FieldToSearchBy)
			.SortBy(queryParams.SortBy, queryParams.SortDirection)
			.Paginate(queryParams.PageNumber, queryParams.PageSize);

		private IQueryable<T> Filter(string? searchTerm, string? fieldToSearchBy)
			=> queryable.Where(CreateStringContainsExpression<T>(fieldToSearchBy, searchTerm));

		private IQueryable<T> SortBy(string? sort, string? direction)
		{
			if (string.IsNullOrWhiteSpace(sort))
				return queryable;

			var parameter = Expression.Parameter(typeof(T), "param");
			var sortByExpression = Expression.Lambda<Func<T, object>>(
									 Expression.Convert(
										Expression.Property(parameter, sort),
										typeof(object)), parameter);

			if ((direction ?? "asc") == "asc")
				return queryable.OrderBy(sortByExpression);

			return queryable.OrderByDescending(sortByExpression);
		}

		private IQueryable<T> Paginate(int page, int size)
			=> queryable
				.Skip((page - 1) * size)
				.Take(size);
	}

	public static Expression<Func<T, bool>> CreateStringContainsExpression<T>(string? propertyName, string? value)
	{
		if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
			return x => true;

		var parameter = Expression.Parameter(typeof(T), "param");
		var property = Expression.Property(parameter, propertyName);
		var toUpperMethod = typeof(string).GetMethod("ToUpperInvariant")!;
		var containsMethod = typeof(string).GetMethod("Contains", [typeof(string)])!;

		var upperCaseProperty = Expression.Call(property, toUpperMethod);
		var searchTerm = Expression.Constant(value.ToUpperInvariant());

		var containsCall = Expression.Call(upperCaseProperty, containsMethod, searchTerm);

		return Expression.Lambda<Func<T, bool>>(containsCall, parameter);
	}
}