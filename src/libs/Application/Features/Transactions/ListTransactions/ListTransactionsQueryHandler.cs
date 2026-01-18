using Application.Common.Data;
using Common.Results;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Transactions.ListTransactions;

public sealed class ListTransactionsQueryHandler(ICashFlowDbContext dbContext)
{
	public async ValueTask<PagedResult<TransactionsListItemDto>> Handle(ListTransactionsQuery query, CancellationToken cancellationToken)
	{
		//This could for sure be optimized with caching (HybridCache?) but for the sake of this example, I'll will keep it simple.
		var categories = await dbContext
								.Categories
								.ToListAsync(cancellationToken);

		var people = await dbContext
								.People
								.ToListAsync(cancellationToken);

		var transactionsQuery = people
							.SelectMany(p => p.Transactions.Select(TransactionsListItemDto.Selector))
							.OrderByDescending(t => t.Date)
							.AsQueryable();

		return PagedResult<TransactionsListItemDto>.Create(
				transactionsQuery,
				query.QueryParams);
	}
}