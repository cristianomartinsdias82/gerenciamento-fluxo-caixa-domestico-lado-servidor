using Common.Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Transactions.RegisterTransaction;

public sealed record RegisteredTransactionDto
{
	public Guid Id { get; init; }
	public Guid PersonId { get; init; } = default!;
	public Guid CategoryId { get; init; } = default!;
	public TransactionType Type { get; init; }
	public string Description { get; init; } = default!;
	public decimal Amount { get; init; }
	public DateTimeOffset Date { get; init; }
}