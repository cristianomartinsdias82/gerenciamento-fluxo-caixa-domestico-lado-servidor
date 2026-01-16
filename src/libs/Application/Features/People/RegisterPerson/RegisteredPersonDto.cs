namespace Application.Features.People.RegisterPerson;

public sealed class RegisteredPersonDto
{
	public Guid Id { get; init; }
	public string FullName { get; init; } = default!;
	public int Age { get; init; }
}
