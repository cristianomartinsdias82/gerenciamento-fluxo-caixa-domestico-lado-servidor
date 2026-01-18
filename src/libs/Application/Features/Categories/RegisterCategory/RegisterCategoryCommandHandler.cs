using Application.Common.Data;
using Domain.Entities;

namespace Application.Features.Categories.RegisterCategory;

public sealed class RegisterCategoryCommandHandler(ICashFlowDbContext dbContext)
{
	public async ValueTask<RegisteredCategoryDto> Handle(RegisterCategoryCommand command, CancellationToken cancellationToken)
	{
		var newCategory = Category.Create(
									command.Name,
									Enum.Parse<CategoryPurpose>(command.Purpose, true),
									command.Description);

		await dbContext.Categories.AddAsync(newCategory, cancellationToken);

		await dbContext.SaveChangesAsync(cancellationToken);

		return new()
		{
			Id = newCategory.Id,
			Name = newCategory.Name,
			Description = newCategory.Description,
			Purpose = newCategory.Purpose.ToString()
		};
	}
}