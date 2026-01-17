using Application.Features.Categories.RegisterCategory;
using Application.Features.Categories.RemoveCategory;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace HouseholdCashFlowManagementApi.Features.Categories;

[ApiController]
[Route("api/[controller]")]
public sealed class CategoriesController(IMessageBus messageBus) : ControllerBase
{
	[HttpPost]
	public async ValueTask<IActionResult> RegisterCategory(
		RegisterCategoryCommand command,
		CancellationToken cancellationToken)
	{
		var registeredCategory = await messageBus.InvokeAsync<RegisteredCategoryDto>(
			command,
			cancellationToken);

		return Ok(registeredCategory);
		//return CreatedAtAction(
		//	nameof(GetCategoryById),
		//	new { id = registeredCategory.Id },
		//	registeredCategory);
	}

	[HttpDelete("{id:guid}")]
	public async ValueTask<IActionResult> RemoveCategory(
		Guid id,
		CancellationToken cancellationToken)
	{
		await messageBus.InvokeAsync(
			new RemoveCategoryCommand { Id = id },
			cancellationToken);

		return NoContent();
	}
}
