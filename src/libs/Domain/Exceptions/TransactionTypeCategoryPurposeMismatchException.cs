using Common.Exceptions;

namespace Domain.Exceptions;

public sealed class TransactionTypeCategoryPurposeMismatchException
	: BusinessRuleException
{
	public TransactionTypeCategoryPurposeMismatchException()
		: this("The transaction type does not match the category purpose.") { }

	public TransactionTypeCategoryPurposeMismatchException(string message)
		: base(message) { }
}