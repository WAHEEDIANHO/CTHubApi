namespace CThub.Application.Pagination;

public class PaginationResult<TEntity> (int pageIndex, int size, long count, IEnumerable<TEntity> items)
{
    public int PageIndex { get; } = pageIndex;
    public int Size { get; } = size;
    public long TotalCount { get; } = count;
    public IEnumerable<TEntity> Items { get; } = items;
}