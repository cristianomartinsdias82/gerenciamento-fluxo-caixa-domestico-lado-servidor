using Application.Common.Data;
using Common.Results;
using Domain.Entities;

namespace Application.Features.Categories.ListCategories;

public sealed class ListCategoriesQueryHandler(ICashFlowDbContext dbContext)
{
	public async ValueTask<PagedResult<CategoriesListItemDto>> Handle(ListCategoriesQuery query, CancellationToken cancellationToken)
		=> await dbContext.MappedQueryAsync<Category, CategoriesListItemDto>(
			query.QueryParams with { FieldToSearchBy = nameof(Category.Name) },
			category => new CategoriesListItemDto
			{
				Id = category.Id,
				Name = category.Name,
				Purpose = new() { Text = category.Purpose.ToString(), Value = (int)category.Purpose }
			},
			cancellationToken);
}