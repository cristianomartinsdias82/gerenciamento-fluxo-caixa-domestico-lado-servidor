namespace Application.Features.People.RegisterPerson;

public sealed record RegisterPersonCommand
{
	public string FullName { get; init; } = default!;
	public int Age { get; init; }
}
