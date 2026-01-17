using Common.Domain;

namespace Domain.Entities;

public sealed class Transaction : IEntity
{
	private Transaction() { }

	public Guid Id {  get; private set; }
	public Category Category { get; private set; } = default!;
	public TransactionType Type { get; private set; }
	public string Description { get; private set; } = default!;
	public decimal Amount { get; private set; }
	public DateTimeOffset Date { get; private set; }

	internal static Transaction Create(
		Category category,
		TransactionType type,
		string description,
		decimal amount,
		DateTimeOffset date)
	{
		if (category.Purpose != CategoryPurpose.Both && (int)type != (int)category.Purpose)
			new ArgumentException("The transaction type does not match the category purpose.", nameof(type));

		return new()
		   {
			   Id = Guid.NewGuid(),
			   Category = category,
			   Type = type,
			   Description = description,
			   Amount = amount,
			   Date = date
		   };
	}
}
