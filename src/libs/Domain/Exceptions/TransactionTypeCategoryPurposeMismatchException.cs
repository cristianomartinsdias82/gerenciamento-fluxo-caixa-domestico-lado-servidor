namespace Domain.Exceptions;

public sealed class TransactionTypeCategoryPurposeMismatchException : Exception
{
	public TransactionTypeCategoryPurposeMismatchException()
	{
		
	}
	public TransactionTypeCategoryPurposeMismatchException(string message) : base(message) { }
}