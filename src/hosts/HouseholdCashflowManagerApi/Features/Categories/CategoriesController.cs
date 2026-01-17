using Application.Features.Categories.RegisterCategory;
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
}
