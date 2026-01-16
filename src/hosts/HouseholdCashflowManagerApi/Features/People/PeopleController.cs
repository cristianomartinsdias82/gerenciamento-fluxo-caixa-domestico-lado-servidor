using Application.Features.People.RegisterPerson;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace HouseholdCashFlowManagementApi.Features.People;

[ApiController]
[Route("api/people")]
public sealed class PeopleController(IMessageBus messageBus) : ControllerBase
{
	[HttpPost]
	public async ValueTask<IActionResult> RegisterPerson(
		RegisterPersonCommand command,
		CancellationToken cancellationToken)
	{
		var registeredPerson = await messageBus.InvokeAsync<RegisteredPersonDto>(
			command,
			cancellationToken);

		return Ok(registeredPerson);
		//return CreatedAtAction(
		//	nameof(GetPersonById),
		//	new { id = registeredPerson.Id },
		//	registeredPerson);
	}
}
