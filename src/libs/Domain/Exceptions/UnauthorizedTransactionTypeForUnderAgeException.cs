using Common.Exceptions;
using Domain.Entities;

namespace Domain.Exceptions;

public sealed class UnauthorizedTransactionTypeForUnderAgeException
	: BusinessRuleException
{
	public UnauthorizedTransactionTypeForUnderAgeException(Person person, int minimumAge)
		: this($"{person.FullName} must be at least {minimumAge} years old to register transactions which purpose is different than Expense.") { }

	public UnauthorizedTransactionTypeForUnderAgeException(string message)
		: base(message) { }
}