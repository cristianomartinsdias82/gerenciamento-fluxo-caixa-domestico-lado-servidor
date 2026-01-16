using Application.Common.Data;
using Domain.Entities;

namespace Application.Features.People.RegisterPerson;

public sealed class RegisterPersonCommandHandler(ICashFlowDbContext dbContext)
{
	public async ValueTask<RegisteredPersonDto> Handle(RegisterPersonCommand command, CancellationToken cancellationToken)
	{
		var newPerson = Person.Create(command.FullName, command.Age);

		var newlyRegisteredPerson = new RegisteredPersonDto
		{
			Id = newPerson.Id,
			FullName = newPerson.FullName,
			Age = newPerson.Age
		};

		await dbContext.People.AddAsync(newPerson, cancellationToken);

		await dbContext.SaveChangesAsync(cancellationToken);

		return newlyRegisteredPerson;
	}
}