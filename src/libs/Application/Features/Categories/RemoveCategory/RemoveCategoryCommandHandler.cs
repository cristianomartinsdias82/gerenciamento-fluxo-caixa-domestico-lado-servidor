using Application.Common.Data;

namespace Application.Features.Categories.RemoveCategory;

public sealed class RemoveCategoryCommandHandler(ICashFlowDbContext dbContext)
{
	public async ValueTask Handle(RemoveCategoryCommand command, CancellationToken cancellationToken)
	{
		var category = dbContext.Categories.SingleOrDefault(p => p.Id == command.Id);

		if (category is null)
			return;

		dbContext.Categories.Remove(category);

		await dbContext.SaveChangesAsync(cancellationToken);
	}
}