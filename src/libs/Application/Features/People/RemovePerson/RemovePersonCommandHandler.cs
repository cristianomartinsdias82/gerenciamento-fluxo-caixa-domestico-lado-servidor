using Application.Common.Data;

namespace Application.Features.People.RemovePerson;

public sealed class RemovePersonCommandHandler(ICashFlowDbContext dbContext)
{
	public async ValueTask Handle(RemovePersonCommand command, CancellationToken cancellationToken)
	{
		var person = dbContext.People.SingleOrDefault(p => p.Id == command.Id);

		if (person is null)
			return;

		dbContext.People.Remove(person);

		await dbContext.SaveChangesAsync(cancellationToken);
	}
}