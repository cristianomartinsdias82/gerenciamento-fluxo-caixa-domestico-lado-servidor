using Common.Domain;

namespace Domain.Entities;

public sealed class Transaction : IEntity
{
	private Transaction() { }

	public Guid Id {  get; private set; }
	public Category Category { get; private set; } = default!;
	public Person Person { get; private set; } = default!;
	public TransactionType Type { get; private set; }
	public string Description { get; private set; } = default!;
	public decimal Amount { get; private set; }
	public DateTimeOffset Date { get; private set; }

	internal static Transaction Create(
		Category category,
		Person person,
		TransactionType type,
		string description,
		decimal amount,
		DateTimeOffset date)
	{
		if (category.Purpose != CategoryPurpose.Both && (int)type != (int)category.Purpose)
			throw new ArgumentException("The transaction type does not match the category purpose.",
										nameof(type));

		if (person.Age < 18 && category.Purpose != CategoryPurpose.Expense)
			throw new ArgumentException($"{person.FullName} must be at least 18 years old to register transactions which purpose is different than Expense.");

		return new()
		{
			Id = Guid.NewGuid(),
			Category = category,
			Person = person,
			Type = type,
			Description = description,
			Amount = amount,
			Date = date
		};
	}
}
