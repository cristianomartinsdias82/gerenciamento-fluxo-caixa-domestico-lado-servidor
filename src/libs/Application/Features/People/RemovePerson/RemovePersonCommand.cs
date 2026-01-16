namespace Application.Features.People.RemovePerson;

public sealed record RemovePersonCommand
{
	public required Guid Id { get; init; }
}
