using Common.Domain;

namespace Domain.Entities;

public sealed class Person : IEntity
{
	private Person() { }

	public Guid Id { get; private set; }
	public string FullName { get; private set; } = default!;
	public int Age { get; private set; }
	public ICollection<Transaction> Transactions { get; private set; } = [];

	public static Person Create(string fullName, int age)
		=> new()
		{
			Id = Guid.NewGuid(),
			FullName = fullName,
			Age = age
		};

	public async ValueTask<bool> AddTransaction(
		Category category,
		TransactionType type,
		string description,
		decimal amount,
		DateTimeOffset date)
	{
		Transactions.Add(
			Transaction.Create(
				category,
				type,
				description,
				amount,
				date));

		return true;
	}
}
