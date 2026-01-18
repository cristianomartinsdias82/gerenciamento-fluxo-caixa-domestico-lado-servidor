namespace Common.Exceptions;

public abstract class BusinessRuleException : Exception
{
	protected BusinessRuleException(string message)
		: base(message) { }
}
