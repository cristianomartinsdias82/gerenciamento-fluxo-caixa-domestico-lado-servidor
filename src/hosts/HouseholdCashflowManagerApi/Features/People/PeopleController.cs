using Application.Features.People.ListPeople;
using Application.Features.People.RegisterPerson;
using Application.Features.People.RemovePerson;
using Application.Features.Transactions.RegisterTransaction;
using Common.Searching;
using HouseholdCashFlowManagementApi.Common.Searching;
using Microsoft.AspNetCore.Mvc;
using Wolverine;

namespace HouseholdCashFlowManagementApi.Features.People;

[ApiController]
[Route("api/[controller]")]
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

	[HttpDelete("{id:guid}")]
	public async ValueTask<IActionResult> RemovePerson(
		Guid id,
		CancellationToken cancellationToken)
	{
		await messageBus.InvokeAsync(
			new RemovePersonCommand { Id = id },
			cancellationToken);

		return NoContent();
	}

	[HttpGet]
	public async ValueTask<IActionResult> ListPeople(
		[FromQuery] QueryParams queryParams,
		CancellationToken cancellationToken)
	{
		var pagedResult = await messageBus.InvokeAsync<PagedResult<PeopleListItemDto>>(
			new ListPeopleQuery { QueryParams = queryParams },
			cancellationToken);

		return Ok(pagedResult);
	}

	[HttpPost("{id:guid}/transactions")]
	public async ValueTask<IActionResult> RegisterTransaction(
		Guid id,
		RegisterTransactionCommand command,
		CancellationToken cancellationToken)
	{
		var registeredTransaction = await messageBus.InvokeAsync<RegisteredTransactionDto>(
			command with { PersonId = id },
			cancellationToken);

		return Ok(registeredTransaction);
		//return CreatedAtAction(
		//	nameof(GetTransactionById),
		//	new { id = registeredTransaction.Id },
		//	registeredPerson);
	}
}
