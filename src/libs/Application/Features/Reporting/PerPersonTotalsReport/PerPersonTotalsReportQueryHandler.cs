using Application.Common.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Reporting.PerPersonTotalsReport;

public sealed class PerPersonTotalsReportQueryHandler(
	ICashFlowDbContext dbContext)
{
	public async ValueTask<PerPersonTotalsReportDto> Handle(PerPersonTotalsReportQuery query, CancellationToken cancellationToken)
	{
		//This could for sure be optimized with caching (HybridCache?) but for the sake of this example, I'll will keep it simple.
		var categories = await dbContext
								.Categories
								.ToListAsync(cancellationToken);

		var people = await dbContext
								.People
								.ToListAsync(cancellationToken);

		var reportLineItems = new List<PerPersonTotalsReportLineItemDto>();
		foreach (var person in people)
			reportLineItems.Add(new PerPersonTotalsReportLineItemDto
			{
				PersonId = person.Id,
				PersonName = person.FullName,
				ExpensesTotal = person.Transactions.Sum(t => t.Type == TransactionType.Expense ? t.Amount : 0M),
				IncomeTotal = person.Transactions.Sum(t => t.Type == TransactionType.Income ? t.Amount : 0M),
			});

		return new() { PerPersonReportLines = reportLineItems };
	}
}