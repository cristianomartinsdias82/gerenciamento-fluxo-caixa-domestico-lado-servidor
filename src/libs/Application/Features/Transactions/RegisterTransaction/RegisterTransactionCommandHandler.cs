using Application.Common.Data;
using Domain.Entities;

namespace Application.Features.Transactions.RegisterTransaction;

public sealed class RegisterTransactionCommandHandler(ICashFlowDbContext dbContext)
{
	public async ValueTask<RegisteredTransactionDto> Handle(RegisterTransactionCommand command, CancellationToken cancellationToken)
	{
		var person = dbContext.People.SingleOrDefault(p => p.Id == command.PersonId);
		if (person is null)
			throw new ArgumentException($"Unable to register the transaction: the person with id {command.PersonId} was not found.");

		var category = dbContext.Categories.SingleOrDefault(p => p.Id == command.CategoryId);
		if (category is null)
			throw new ArgumentException($"Unable to register the transaction: the category with id {command.CategoryId} was not found.");

		var transaction = await person.AddTransaction(
			category,
			Enum.Parse<TransactionType>(command.Type, true),
			command.Description,
			command.Amount,
			DateTimeOffset.UtcNow);

		await dbContext.SaveChangesAsync(cancellationToken);

		return new()
		{
			Id = transaction.Id,
			CategoryId = transaction.Category.Id,
			PersonId = transaction.Person.Id,
			Amount = transaction.Amount,
			Type = transaction.Type.ToString(),
			Description = transaction.Description
		};
	}
}