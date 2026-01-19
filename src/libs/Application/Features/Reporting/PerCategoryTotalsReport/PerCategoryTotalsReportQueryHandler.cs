using Application.Common.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Reporting.PerCategoryTotalsReport;

public sealed class PerCategoryTotalsReportQueryHandler(
	ICashFlowDbContext dbContext)
{
	public async ValueTask<PerCategoryTotalsReportDto> Handle(PerCategoryTotalsReportQuery query, CancellationToken cancellationToken)
	{
		//This could for sure be optimized with caching (HybridCache?) but for the sake of this example, I'll will keep it simple.
		var categories = await dbContext
								.Categories
								.ToListAsync(cancellationToken);

		var people = await dbContext
								.People
								.ToListAsync(cancellationToken);

		var reportLineItems = new List<PerCategoryTotalsReportLineItemDto>();

		var groupedTransactions = people
							.SelectMany(people => people.Transactions)
							.GroupBy(gr => gr.Category.Name);

		foreach (var transactionGroup in groupedTransactions)
			reportLineItems.Add(new PerCategoryTotalsReportLineItemDto
			{
				CategoryId = categories.First(c => c.Name == transactionGroup.Key).Id,
				CategoryName = transactionGroup.Key,
				ExpensesTotal = transactionGroup.Sum(t => t.Type == TransactionType.Expense ? t.Amount : 0M),
				IncomeTotal = transactionGroup.Sum(t => t.Type == TransactionType.Income ? t.Amount : 0M),
			});

		return new() { PerCategoryReportLines = reportLineItems };
	}
}